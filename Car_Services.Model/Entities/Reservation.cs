using Car_Service.Model.Entities;
using System.Collections.Generic;

namespace Car_Service.DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Worker Worker { get; set; }

        public string Purpose { get; set; }
        public string BreakdownDetails { get; set; }
        public string DesiredDiagnosis { get; set; }

        public string Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

        public List<Image> Images { get; set; }
    }
}
