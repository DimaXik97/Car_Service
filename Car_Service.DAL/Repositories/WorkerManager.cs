using Car_Service.DAL.EF;
using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Car_Service.DAL.Repositories
{
    public class WorkerManager : IWorkerManager
    {
        public ApplicationContext Database { get; set; }
        public WorkerManager(ApplicationContext db)
        {
            Database = db;
        }
        public List<Worker> Get()
        {
            return Database.Worker.ToList();
        }
        public void Create(Worker item)
        {
            Database.Worker.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}