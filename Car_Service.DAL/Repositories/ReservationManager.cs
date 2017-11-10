using Car_Service.DAL.EF;
using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;


namespace Car_Service.DAL.Repositories
{
    public class ReservationManager : IReservationManager
    {
        public ApplicationContext Database { get; set; }
        public ReservationManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Reservation item)
        {
            Database.Reservation.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}