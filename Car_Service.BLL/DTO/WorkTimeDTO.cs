using System.ComponentModel.DataAnnotations;

namespace Car_Service.BLL.DTO
{
    public class WorkTimeDTO
    {
        public int UserId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
    }
}
