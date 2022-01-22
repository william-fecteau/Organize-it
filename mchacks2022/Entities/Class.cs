using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mchacks2022.Entities
{
    public class Class
    {
        [Key]
        public Guid Id { get; set; }
        public string ClassNum { get; set; }  // Example GLO-1111
        public string Name { get; set; }

        public string FkUserId { get; set; }
        public virtual IdentityUser FkUser { get; set; }
    }
}
