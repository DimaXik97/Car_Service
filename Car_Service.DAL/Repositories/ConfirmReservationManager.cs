using Car_Service.DAL.EF;
using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;
using System.Data.Entity;
using System;
using System.Linq;

namespace Car_Service.DAL.Repositories
{
    public class ConfirmReservationManager : IConfirmReservation
    {
        public ApplicationContext Database { get; set; }
        public ConfirmReservationManager(ApplicationContext db)
        {
            Database = db;
        }
        public ConfirmReservation Get(Guid guid)
        {
           return Database.ConfirmReservation.FirstOrDefault(s=>s.Guid==guid);
        }
        public void Create(ConfirmReservation item)
        {
            try
            {

                Database.ConfirmReservation.Add(item);
                Database.SaveChanges();
            }
            catch(Exception e)
            {

            }
           
        }
        

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Update(ConfirmReservation item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.SaveChanges();
        }

        
    }
}
