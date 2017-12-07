using Car_Service.BLL.DTO;
using Car_Service.BLL.Infrastructure;
using Car_Service.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Car_Service.Controllers
{
    public class AccountController : ApiController
    {
        private IUserService UserService;

        public AccountController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Register([FromBody]UserDTO model)
        {
            await SetInitialDataAsync();
            if (model!=null)
            {
                model.Role = "user";
                OperationDetails operationDetails = await UserService.Create(model);
                if (operationDetails.Succedeed)
                    return Ok();
                else
                    return BadRequest(operationDetails.Message);
            }
            return BadRequest();

        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "ydn@mail.ru",
                UserName = "ydn@mail.ru",
                Password = "12345Qaz",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}
