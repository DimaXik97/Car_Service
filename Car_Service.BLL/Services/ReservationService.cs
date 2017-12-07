﻿using Car_Service.BLL.Interfaces;
using Car_Service.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Service.BLL.DTO;
using Car_Service.BLL.Infrastructure;
using static Car_Service.BLL.DTO.ReservationDTO;
using System.IO;
using Car_Service.DAL.Entities;
using Car_Service.Helpers;

namespace Car_Service.BLL.Services
{
    public class ReservationService : IReservationService
    {
        string ImagePath { get;}
        IUnitOfWork Database { get; set; }
        IWorkerService WorkerService { get; set; }

        public ReservationService(IUnitOfWork uow)
        {
            Database = uow;
            WorkerService = new WorkerService(uow);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> Create(ReservationDTO model, string curentUserId, string pathFolder) 
        {
            var curentUser = await Database.UserManager.FindByIdAsync(curentUserId);
            var reservation = new Reservation
            {
                ApplicationUser = curentUser,
                Worker = Database.WorkerManager.Get().Find(s => s.Id == model.WorkerId),
                Purpose = model.Purpose,
                BreakdownDetails = model.BreakdownDetails,
                DesiredDiagnosis = model.DesiredDiagnosis,
                
            };
            var isVerify = await verifyCaptcha(model.Captcha);
            if (!isVerify)
            {
                return new OperationDetails(false, "Error captcha", "");
            }
            else if(model.isEmergency)
            {
                DateTime startTime;
                DateTime endTime;
                var worker = GetEmergencyTime(out startTime, out endTime);
                reservation.DateStart = startTime;
                reservation.DateEnd = endTime;
                reservation.Worker = Database.WorkerManager.Get().Find(s => s.Id == worker);
            }
            else
            {
                if(await verifyTime(model.WorkerId, model.TimeStart, model.TimeEnd))
                {
                    reservation.DateStart = model.TimeStart;
                    reservation.DateEnd = model.TimeEnd;
                }
                else
                    return new OperationDetails(false, "Error date", "");
            }
            Database.ReservationManager.Create(reservation);
            await UploadImage(model.File, reservation, pathFolder);
            var confirmReservation = new ConfirmReservation { Id = reservation.Id, Guid = Guid.NewGuid(), Reservation = reservation, IsConfirm = false, ExpireDate = DateTime.Now.AddMinutes(5).ToUniversalTime() };
            Database.ConfirmReservationManager.Create(confirmReservation);
            SendEmail.ConfirmReservation(reservation, confirmReservation);
            return new OperationDetails(true, "", "");
        }
        private int GetEmergencyTime(out DateTime dateStart, out DateTime dateEnd)
        {
            var minFreeTime =new Dictionary<int, DateTime>(); 
            var workers = Database.WorkerManager.Get();
            foreach(var worker in workers)
            {
                var workTimeWorker = Database.WorkTimeManager.Get().Where(s => s.Worker.Id == worker.Id&&s.DateEnd>=DateTime.Now.ToUniversalTime()).ToList();
                if (workTimeWorker.Count!=0)
                {
                    var curentTime = new DateTime(((DateTime.Now.Ticks + TimeSpan.FromMinutes(60).Ticks - 1) / TimeSpan.FromMinutes(60).Ticks) * TimeSpan.FromMinutes(60).Ticks).ToUniversalTime();
                    var minTime = (workTimeWorker.Find(s=> curentTime >= s.DateStart&& curentTime < s.DateEnd)!=null)? curentTime : workTimeWorker.Where(s=>s.DateStart>DateTime.Now.ToUniversalTime()).Min(s => s.DateStart);
                    while (minTime != null)
                    {
                        var reservationTime = Database.ReservationManager.Get().Find(s => (minTime >= s.DateStart && minTime < s.DateEnd)&& (s.ConfirmReservation.IsConfirm || s.ConfirmReservation.ExpireDate >= DateTime.Now.ToUniversalTime()));
                        if (reservationTime != null)
                        {
                            if (workTimeWorker.Any(s => reservationTime.DateEnd >= s.DateStart && reservationTime.DateEnd < s.DateEnd))
                                minTime = reservationTime.DateEnd;
                            else
                                minTime = workTimeWorker.Where(s => s.DateStart >= reservationTime.DateEnd).Min(s => s.DateEnd);
                        }
                        else
                        {
                            minFreeTime.Add(worker.Id, minTime);
                            break;
                        }
                    }
                }
            }
            var result = minFreeTime.First(s => s.Value == minFreeTime.Min(k => k.Value));
            dateStart = DateTime.SpecifyKind(result.Value, DateTimeKind.Utc);
            dateEnd= DateTime.SpecifyKind(dateStart.AddHours(1), DateTimeKind.Utc);
            return result.Key;
        }
        private async Task UploadImage(List<ImageDTO> images, Reservation reservation, string pathFolder)
        {
            int i = 1;
            foreach (var image in images)
            {
                string fileName = string.Format("{0}_{1}{2}", reservation.Id, i, image.Extension);
                string path = string.Format("{0}/{1}",pathFolder, fileName);
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await fs.WriteAsync(image.ImageBytes, 0, image.ImageBytes.Length);
                    Database.ImageManager.Create(new Image { URL = path, Reservation = reservation });
                }
                i++;
            }
        }
        private async Task<bool> verifyCaptcha(string captcha)
        {
            var responce = await ReCaptcha.GetRespons(captcha);
            return ReCaptcha.Validate(responce); ;
        }
        private async Task<bool> verifyTime(int workerId,DateTime dateStart, DateTime dateEnd)
        {
            if (!(dateStart.Date>=DateTime.Now.ToUniversalTime().Date&&dateStart.Hour>=DateTime.Now.ToUniversalTime().Hour))
                return false;
            var workTimes = Database.WorkTimeManager.Get().Where(s => s.Worker.Id == workerId ).ToList();
            var reservationTimes = Database.ReservationManager.Get().Where(s => s.Worker.Id == workerId&&(s.ConfirmReservation.IsConfirm||s.ConfirmReservation.ExpireDate>=DateTime.Now.ToUniversalTime())).ToList();
            if (workTimes.Where(s => dateStart >= s.DateStart && dateStart < s.DateEnd && dateEnd > s.DateStart && dateEnd <= s.DateEnd).Count() != 1)
                return false;
            else if (reservationTimes.Where(s=>((dateStart >= s.DateStart) && (dateStart < s.DateEnd)) || ((dateEnd > s.DateStart) && (dateEnd <= s.DateEnd)) || ((s.DateStart >= dateStart) && (s.DateEnd <= dateEnd))).Count()!=0)
            {
                return false;
            }
            else return true;
        }

        public OperationDetails Confirm(Guid guid)
        {
            var entity = Database.ConfirmReservationManager.Get(guid);
            if(entity!=null&& entity.ExpireDate<=DateTime.Now&& !entity.IsConfirm)
            {
                entity.IsConfirm = true;
                Database.ConfirmReservationManager.Update(entity);
                return new OperationDetails(true, "", "");
            }
            else 
                return new OperationDetails(false, "Error guid or time extire", "");
        }
    }
}
 