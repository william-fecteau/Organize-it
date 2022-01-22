using System;
using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class CreateSemesterRequest
    {
        [Required]
        public string SemesterName { get; set; } // Example: H2022
        [Required]
        public DateTime EasternStartDate { get; set; }
        [Required]
        public int NbWeeks { get; set; }
    }
}
