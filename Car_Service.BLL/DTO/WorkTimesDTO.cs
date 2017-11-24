using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.BLL.DTO
{
    public class WorkTimesDTO
    {
        public int WorkerId { get; set; }
        public List<WorkTime> WorkTimesWorker { get; set; }
        public class WorkTime
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }
}
