using System;
using System.Collections.Generic;
using Car_Service.DAL.EF;
using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Car_Service.DAL.Repositories
{
    public class WorkTimeManager : IWorkTimeManager
    {
        public ApplicationContext Database { get; set; }
        public WorkTimeManager(ApplicationContext db)
        {
            Database = db;
        }
        public List<WorkTime> Get()
        {
            return Database.WorkTime.ToList();
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
