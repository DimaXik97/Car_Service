using Car_Service.BLL.Interfaces;
using Car_Service.Model.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Car_Service.BLL.Infrastructure;
using Car_Service.DAL.Entities;
using System.Linq;
using Car_Service.BLL.DTO;
using System.Collections;

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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
