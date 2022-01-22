using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
