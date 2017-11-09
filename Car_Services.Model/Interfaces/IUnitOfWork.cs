using Car_Service.DAL.Interfaces;
using Car_Service.Model.Identity;
using System;

using System.Threading.Tasks;

namespace Car_Service.Model.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IWorkerManager WorkerManager { get; }
        IWorkTimeManager WorkTimeManager { get; }
        IImageManager ImageManager { get; }
        IReservationManager ReservationManager { get; }
        Task SaveAsync();
    }
}