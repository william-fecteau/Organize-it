using System;
using System.Collections.Generic;
using mchacks2022.Entities;

namespace mchacks2022.DTOs
{
    public class CompleteSemesterClass
    {
        public SemesterClass SemesterClass { get; set; }
        public List<SemesterClassSchedule> Schedules { get; set; }
    }
}
