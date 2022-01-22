using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mchacks2022.Entities
{
    public enum ClassType
    {
        InClass,
        Online,
        Comodal
    }

    public class SemesterClassSchedule
    {
        [Key]
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan DurationHours { get; set; }
        public ClassType ClassType { get; set; }


        // Semester class composite keys
        public Guid FkSemesterId { get; set; }
        public Semester FkSemester { get; set; }
        public Guid FkClassId { get; set; }
        public Class FkClass { get; set; }
        [ForeignKey("FkSemesterId, FkClassId")]
        public SemesterClass FkSemesterClass { get; set; }
    }
}
