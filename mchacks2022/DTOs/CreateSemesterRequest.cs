using System;

namespace mchacks2022.DTOs
{
    public class CreateSemesterRequest
    {
        public string SemesterName { get; set; } // Example: H2022
        public DateTime EasternStartDate { get; set; }
        public int NbWeeks { get; set; }
    }
}
