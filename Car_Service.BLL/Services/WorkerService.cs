using Car_Service.BLL.Interfaces;
using Car_Service.Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Car_Service.BLL.Infrastructure;
using Car_Service.DAL.Entities;
using System.Linq;
using Car_Service.BLL.DTO;
using System.Collections;
using System;
using System.Globalization;

namespace Car_Service.BLL.Services
{
    public class WorkerService: IWorkerService
    {
        IUnitOfWork Database { get; set; }

        public WorkerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<WorkerDTO> GetWorker()
        {
            return Database.WorkerManager.Get().Select(s=>new WorkerDTO { Id=s.Id, Name=s.FirstName, SurName=s.SurName, Telephone=s.Telephone, Email=s.Email}).ToList();
        }
        public async Task<OperationDetails> AddWorker(WorkerDTO model)
        {
            var worker = Database.WorkerManager.Get().Find(s=>s.Email==model.Email);
            if(worker==null)
            {
                worker = new Worker
                {
                    FirstName = model.Name,
                    SurName = model.SurName,
                    Telephone = model.Telephone,
                    Email = model.Email
                };
                Database.WorkerManager.Create(worker);
                return new OperationDetails(true, "Рабочий успешно добавлен", "");
            }
            return new OperationDetails(false, "Рабочий с таким e-mail уже существует", "Email");
        }
        public OperationDetails AddWorkTime(WorkTimeDTO model)
        {
            DateTime curentDate = DateTime.Now;
            Worker worker = Database.WorkerManager.Get().Find(s => s.Id == model.UserId);
            model.StartTime.ToLocalTime();
            model.EndTime.ToLocalTime();
            if (worker == null)
                return new OperationDetails(false, "Рабочий не найден", "");
            else if(model.StartTime < curentDate || model.EndTime < model.StartTime)
                return new OperationDetails(false, "Ошибка даты", "");
            var workerWorkTime = Database.WorkTimeManager.Get().Where(s => (s.Worker == worker));
            if (workerWorkTime == null)
                return new OperationDetails(false, "", "");
            else
            {
                foreach (var x in workerWorkTime)
                {
                    if (((model.StartTime >= x.DateStart) && (model.StartTime < x.DateEnd)) || ((model.EndTime > x.DateStart) && (model.EndTime <= x.DateEnd)) || ((x.DateStart >= model.StartTime) && (x.DateEnd <= model.EndTime)))
                        return new OperationDetails(false, "Уже работает в эту дату", "");
                }
                    
            }
            
            WorkTime workTime = new WorkTime{
                DateStart = model.StartTime,
                DateEnd = model.EndTime,
                Worker=worker
            };
            Database.WorkTimeManager.Create(workTime);
            return new OperationDetails(true, "Время работы успешно добавлено", "");
        }
        public WorkTimesDTO workerTimes(int workerId)
        {
            var worker = Database.WorkerManager.Get().Find(s => s.Id == workerId);
            if (worker != null)
            {
                var workTime = Database.WorkTimeManager.Get().Where(s => s.Worker.Id == workerId && s.DateStart.CompareTo(DateTime.Now) > 0).Select(s=> { return new WorkTimesDTO.WorkTime { StartTime = s.DateStart, EndTime = s.DateEnd }; }).ToList<WorkTimesDTO.WorkTime>();
                return new WorkTimesDTO
                {
                    WorkerId = workerId,
                    WorkTimesWorker = workTime
                };
            }
            else
                return null;
        }
        /*public FreeDateDTO FreeDate(int workerId)
        {
            List<DateTime> freeDates = new List<DateTime>();
            var worker = Database.WorkerManager.Get().Find(s => s.Id == workerId);
            var workDates = Database.WorkTimeManager.Get().Where(s => s.Worker.Id == workerId && s.DateStart.CompareTo(DateTime.Now)>0);
            foreach(var workDate in workDates)
            {
                var reservationTime = Database.ReservationManager.Get().Where(s => s.DateStart.Date == workDate.DateStart.Date&&s.Worker.Id==workerId).ToList();
                var freeTimes = GetFreeTime(workDate.DateStart, workDate.DateEnd, reservationTime);
                freeDates.AddRange(freeTimes);
            }
            return new FreeDateDTO {
                WorkerName = string.Format("{0} {1}", worker.SurName, worker.FirstName),
                TypeSplit = "minute",
                ValueSplit = 60,
                FreeDates = freeDates
            };
        }
        private List<DateTime> GetFreeTime(DateTime startTime, DateTime endTime, List<Reservation> reservationTime)
        {
            List<DateTime> intervalTime = new List<DateTime>();
            while (startTime < endTime)
            {
                bool IsReservation = false;
                foreach (var element in reservationTime)
                {
                    if (!(startTime >= element.DateStart && startTime < element.DateEnd))
                        IsReservation = true;
                }
                if(!IsReservation)
                    intervalTime.Add(startTime);
                startTime = startTime.AddMinutes(60);
            }
            return intervalTime;
        }*/
        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
