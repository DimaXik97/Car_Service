using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;
using Car_Service.Model.EF;


namespace Car_Service.DAL.Repositories
{
    class WorkerManager : IWorkerManager
    {
        public ApplicationContext Database { get; set; }
        public WorkerManager(ApplicationContext db)
        {
            Database = db;
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