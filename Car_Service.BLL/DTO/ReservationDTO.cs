using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.BLL.DTO
{
    public class ReservationDTO
    {
        public int WorkerId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public string BreakdownDetails { get; set; }
        [Required]
        public string DesiredDiagnosis { get; set; }
        public List<ImageDTO> File { get; set; }
        public class ImageDTO
        {
            public byte[] ImageBytes { get; set; }
            public string Extension { get; set; }
        }
    }
}
