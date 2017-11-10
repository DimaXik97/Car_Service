using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.DAL.Entities
{
    public class WorkTime
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        public Worker Worker { get; set; }
    }
}
