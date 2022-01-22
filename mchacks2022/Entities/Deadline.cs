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
        public virtual IdentityUser FkUser { get; set; }

        // Semester class composite keys
        public Guid FkSemesterId { get; set; }
        public virtual Semester FkSemester { get; set; }
        public Guid FkClassId { get; set; }
        public virtual Class FkClass { get; set; }
        [ForeignKey("FkSemesterId, FkClassId")]
        public virtual SemesterClass FkSemesterClass { get; set; }
    }
}
