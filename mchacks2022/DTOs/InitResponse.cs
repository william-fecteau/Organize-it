using mchacks2022.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class InitResponse
    {
        public IdentityUser user { get; set; }
        public List<Semester> semesters { get; set; }
    }
}
