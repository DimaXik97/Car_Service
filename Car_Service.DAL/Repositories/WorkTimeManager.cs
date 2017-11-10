using Car_Service.DAL.EF;
using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;


namespace Car_Service.DAL.Repositories
{
    public class WorkTimeManager : IWorkTimeManager
    {
        public ApplicationContext Database { get; set; }
        public WorkTimeManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(WorkTime item)
        {
            Database.WorkTime.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
