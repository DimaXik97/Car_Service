using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.BLL.DTO
{
    public class TimesDTO
    {
        public int WorkerId { get; set; }
        public List<Time> WorkTimesWorker { get; set; }
        public class Time
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }
}
