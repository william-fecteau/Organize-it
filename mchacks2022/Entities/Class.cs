using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mchacks2022.Entities
{
    public class Class
    {
        [Key]
        public string Id { get; set; } // Example GLO-1111
        public string Name { get; set; }

        public string FkUserId { get; set; }
        public IdentityUser FkUser { get; set; }
    }
}
