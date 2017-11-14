using Car_Service.BLL.Interfaces;
using Car_Service.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Car_Service.Controllers
{
    public class ReservationController : ApiController
    {
        private IReservationService ReservationService;
        public ReservationController(IReservationService reservationService)
        {
            ReservationService = reservationService;
        }

        public IHttpActionResult Get()
        {
            Trace.WriteLine("11234");
            return Ok("Ok");
        }
        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new CustomMultipartFileStreamProvider();
            // путь к папке на сервере
            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/");
            await Request.Content.ReadAsMultipartAsync(provider);

            
            return Ok(provider.Reservation);
        }
    }
}
