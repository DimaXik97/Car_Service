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
            DateTime curentDate = DateTime.Now.ToUniversalTime();
            Worker worker = Database.WorkerManager.Get().Find(s => s.Id == model.UserId);
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
        public TimesDTO workerTimes(int workerId)
        {
            var worker = Database.WorkerManager.Get().Find(s => s.Id == workerId);
            if (worker != null) 
            {
                var workTime = Database.WorkTimeManager.Get().Where(s => s.Worker.Id == workerId && (s.DateStart.Date>=DateTime.Now.ToUniversalTime().Date)).Select(s=> { return new TimesDTO.Time { StartTime = DateTime.SpecifyKind(s.DateStart, DateTimeKind.Utc), EndTime = DateTime.SpecifyKind(s.DateEnd, DateTimeKind.Utc) }; }).ToList<TimesDTO.Time>();
                return new TimesDTO
                {
                    WorkerId = workerId,
                    WorkTimesWorker = workTime
                };
            }
            else
                return null;
        }
        public dynamic reservationTimes(int workerId)
        {
            var worker = Database.WorkerManager.Get().Find(s => s.Id == workerId);
            if (worker != null)
            {
                var workTime = Database.ReservationManager.Get().Where(s => s.Worker.Id == workerId && (s.DateStart.Date >= DateTime.Now.ToUniversalTime().Date) && (s.ConfirmReservation.IsConfirm || s.ConfirmReservation.ExpireDate >= DateTime.Now.ToUniversalTime())).ToList().Select(s => { return new TimesDTO.Time { StartTime = DateTime.SpecifyKind(s.DateStart, DateTimeKind.Utc), EndTime = DateTime.SpecifyKind(s.DateEnd, DateTimeKind.Utc) }; }).ToList<TimesDTO.Time>();
                return new
                {
                    WorkerId = workerId,
                    ReservationTimeWorekr = workTime
                };
            }
            else
                return null;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
