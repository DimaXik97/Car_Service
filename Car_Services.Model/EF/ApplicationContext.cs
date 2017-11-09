using Car_Service.DAL.DBinitializer;
using Car_Service.DAL.Entities;
using Car_Service.Model.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Car_Service.Model.EF
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
