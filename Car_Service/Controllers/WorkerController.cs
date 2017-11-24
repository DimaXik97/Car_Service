using System;
using System.Collections.Generic;
using Car_Service.BLL.DTO;
using System.Web.Http;
using System.Linq;
using Car_Service.BLL.Interfaces;
using System.Collections;
using Car_Service.BLL.Infrastructure;
using System.Threading.Tasks;

namespace Car_Service.Controllers
{
    public class WorkerController : ApiController
    {
        private IWorkerService WorkerService;
        public WorkerController(IWorkerService workerService)
        {
            WorkerService = workerService;
        }

        public IHttpActionResult Get()
        {
            return Ok(WorkerService.GetWorker());
        }

        [Route("api/worker/{workerId}")]
        [HttpGet]
        public IHttpActionResult Get(int workerId)
        {
            return Ok(WorkerService.GetWorker().Find(s=>s.Id== workerId));
        }

        [Authorize(Roles = "admin")]
        public async Task<IHttpActionResult> Post([FromBody] WorkerDTO worker)
        {
            if (ModelState.IsValid && worker != null)
            {
                OperationDetails result= await WorkerService.AddWorker(worker);
                if (result.Succedeed)
                    return Ok();
                else
                    return BadRequest(result.Message);
            }
            else return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
        }

        [Route("api/worker/{workerId}/workTime")]
        [HttpGet]
        public IHttpActionResult GetWorkDate(int workerId)
        {
            try
            {
                var result = WorkerService.workerTimes(workerId);
                if (result == null)
                    return BadRequest("Рабочий не найден");
                else
                    return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Внутренняя ошибка");
            }

        }

        [Authorize(Roles = "admin")]
        [Route("api/worker/{workerId}/workTime")]
        [HttpPost] 
        public IHttpActionResult SetWorkTime([FromBody] WorkTimeDTO workTime,int workerId)
        {
            if (ModelState.IsValid&&workTime!=null)
            {
                workTime.UserId = workerId;
                OperationDetails result = WorkerService.AddWorkTime(workTime);
                if (result.Succedeed)
                    return Ok();
                else
                    return BadRequest(result.Message);
            }
            else return BadRequest(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
        }
    }
}
