using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Car_Service.BLL.DTO
{
    public class ReservationDTO
    {
        public int WorkerId { get; set; }
        [Required]
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public bool isEmergency { get; set; }
        public string Purpose { get; set; }
        public string BreakdownDetails { get; set; }
        public string DesiredDiagnosis { get; set; }
        [Required]
        public string Captcha { get; set; }
        public List<ImageDTO> File { get; set; }
        public class ImageDTO
        {
            public byte[] ImageBytes { get; set; }
            public string Extension { get; set; }
        }
    }
}
