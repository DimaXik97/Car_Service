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

        public List<dynamic> GetWorker()
        {
            return Database.WorkerManager.Get().Select(s=>new { firstName=s.FirstName, surName=s.SurName}).ToList<dynamic>();
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
            string formatString = "dd.MM.yyyy/HH.mm";
            DateTime curentDate = DateTime.Now;
            DateTime startDate = DateTime.ParseExact(string.Format("{0}/{1}",model.Date,model.StartTime), formatString, null);
            DateTime endDate = DateTime.ParseExact(string.Format("{0}/{1}", model.Date, model.EndTime), formatString, CultureInfo.InvariantCulture);
            Worker worker = Database.WorkerManager.Get().Find(s => s.Id == model.UserId);
            if (worker == null)
                return new OperationDetails(false, "Рабочий не найден", "");
            else if(startDate < curentDate || endDate < startDate)
                return new OperationDetails(false, "Ошибка даты", "");
            var isWorkToday = Database.WorkTimeManager.Get().Find(s => (s.Worker == worker)&&(s.DateStart.Date.CompareTo(startDate.Date)==0))!=null;
            if(isWorkToday)
                return new OperationDetails(false, "Уже работает в эту дату", "");
            else
            {
                WorkTime workTime = new WorkTime{
                    DateStart = startDate,
                    DateEnd = endDate,
                    Worker=worker
                };
                Database.WorkTimeManager.Create(workTime);
                return new OperationDetails(true, "Время работы успешно добавлено", "");
            }

        }
        public List<dynamic> FreeDate(int workerId)
        {
            Dictionary<DateTime, List<DateTime>> freeDates = new Dictionary<DateTime, List<DateTime>>();
            var workDates = Database.WorkTimeManager.Get().Where(s => s.Worker.Id == workerId && s.DateStart.CompareTo(DateTime.Now)>0);
            foreach(var workDate in workDates)
            {
                var reservationTime = Database.ReservationManager.Get().Where(s => s.DateStart.Date == workDate.DateStart.Date&&s.Worker.Id==workerId).ToList();
                var freeTimes = GetFreeTime(workDate.DateStart, workDate.DateEnd, reservationTime);
                freeDates.Add(workDate.DateStart.Date, freeTimes);
            }
            return ToFormat(freeDates);
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
                startTime = startTime.AddHours(1);
            }
            return intervalTime;
        }
        private List<dynamic> ToFormat(Dictionary<DateTime, List<DateTime>> freeDates)
        {
            return freeDates.Select(s => new { date = s.Key.ToString("dd.MM.yyyy"), time = s.Value.Select(t => t.ToString("HH.mm")) }).ToList<dynamic>();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
