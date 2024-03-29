﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mchacks2022.Entities
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public DateTime EasternStartTime { get; set; }
        public TimeSpan DurationHour { get; set; }

        // Semester class composite keys
        public Guid FkSemesterId { get; set; }
        public virtual Semester FkSemester { get; set; }
        public Guid FkClassId { get; set; }
        public virtual Class FkClass { get; set; }
        [ForeignKey("FkSemesterId, FkClassId")]
        public virtual SemesterClass FkSemesterClass { get; set; }
    }
}
