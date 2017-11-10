﻿using System.ComponentModel.DataAnnotations;

namespace Car_Service.BLL.DTO
{
    public class WorkerDTO
    {
        [MaxLength(15)]
        [Required]
        public string Name { get; set; }
        [MaxLength(30)]
        [Required]
        public string SurName { get; set; }
        [Phone]
        [Required]
        public string Telephone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
