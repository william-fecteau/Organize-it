using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class LoginResponse
    {
        public string Jwt { get; set; }
        public IdentityUser user { get; set; }
    }
}
