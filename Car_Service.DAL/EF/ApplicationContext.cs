using Car_Service.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Car_Service.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<Image> Image { get; set; }
        public DbSet<WorkTime> WorkTime { get; set; }
        public DbSet<Worker> Worker { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}
