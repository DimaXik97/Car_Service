using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Car_Service.Controllers
{
    public class DefaultController : ApiController
    {
        [Authorize(Roles = "admin")]
        public IEnumerable<string> Get()
        {
            return new List<string> { "OK", "Ok1" };
        }
    }
}
