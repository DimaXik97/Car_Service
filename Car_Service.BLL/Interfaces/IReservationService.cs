using Car_Service.BLL.DTO;
using Car_Service.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.BLL.Interfaces
{
    public interface IReservationService : IDisposable
    {
        Task<OperationDetails> Create(ReservationDTO userDto, string curentUserId);
        OperationDetails Confirm(Guid guid);

    }
}
