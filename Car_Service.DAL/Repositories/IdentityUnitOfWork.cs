using Car_Service.DAL.EF;
using Car_Service.DAL.Entities;
using Car_Service.DAL.Identity;
using Car_Service.DAL.Interfaces;
using Car_Service.Model.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace Car_Service.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IWorkerManager workerManager;
        private IWorkTimeManager workTimeManager;
        private IImageManager imageManager;
        private IReservationManager reservationManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            workerManager = new WorkerManager(db);
            workTimeManager = new WorkTimeManager(db);
            imageManager = new ImageManager(db);
            reservationManager = new ReservationManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IWorkerManager WorkerManager
        {
            get { return workerManager; }
        }

        public IWorkTimeManager WorkTimeManager
        {
            get { return workTimeManager; }
        }

        public IImageManager ImageManager
        {
            get { return imageManager; }
        }

        public IReservationManager ReservationManager
        {
            get { return reservationManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
