using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class AddClassRequest
    {
        [Required]
        public string ClassNum { get; set; } // Example GLO-1111
        [Required]
        public string Name { get; set; }
    }
}
