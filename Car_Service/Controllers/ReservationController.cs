using Car_Service.BLL.DTO;
using Car_Service.BLL.Interfaces;
using Car_Service.Providers;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace Car_Service.Controllers
{
    public class ReservationController : ApiController
    {
        IReservationService ReservationService;
        public ReservationController(IReservationService reservationService)
        {
            ReservationService = reservationService;
        }
        public IHttpActionResult Get()
        {
            return Ok("Ok");
        }
       [Authorize]
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new CustomMultipartFileStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var reservation = provider.Reservation;
            Validate<ReservationDTO>(reservation);
            if (ModelState.IsValid && reservation != null)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var userId = identity.Claims.FirstOrDefault(s=>s.Type=="id").Value;
                return Ok(await ReservationService.Create(reservation, userId));
            }
            else return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
  
        }
    }
}
