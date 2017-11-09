using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;
using Car_Service.Model.EF;


namespace Car_Service.DAL.Repositories
{
    class ReservationManager : IReservationManager
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