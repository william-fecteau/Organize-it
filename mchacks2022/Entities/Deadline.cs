using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace mchacks2022.Entities
{
    public class Deadline
    {
        public Guid Id { get; set; }
        public DateTime EasterDueDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Percentage { get; set; }

        public string FkUserId { get; set; }
        public IdentityUser FkUser { get; set; }

        // Semester class composite keys
        public string FkSemesterId { get; set; }
        public Semester FkSemester { get; set; }
        public string FkClassId { get; set; }
        public Class FkClass { get; set; }
        [ForeignKey("FkSemesterId, FkClassId")]
        public SemesterClass FkSemesterClass { get; set; }
    }
}
