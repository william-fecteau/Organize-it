using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace mchacks2022.Entities
{
    public class SemesterClass
    {
        [Key, Column(Order = 0)]
        public string FkSemesterId { get; set; }

        [Key, Column(Order = 1)]
        public string FkClassId { get; set; }

        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string Note { get; set; }

        public string FkUserId { get; set; }
        public IdentityUser FkUser { get; set; }
    }
}
