﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace mchacks2022.Entities
{
    public class Semester
    {
        [Key]
        public Guid Id { get; set; } 
        public string SemesterName { get; set; } // Example: H2022
        public DateTime EasternStartDate { get; set; }
        public int NbWeeks { get; set; }

        public string FkUserId { get; set; }
        public virtual IdentityUser FkUser { get; set; }
    }
}
