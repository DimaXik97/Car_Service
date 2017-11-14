using Car_Service.BLL.Interfaces;
using Car_Service.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.BLL.Services
{
    public class ReservationService : IReservationService
    {
        IUnitOfWork Database { get; set; }

        public ReservationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
