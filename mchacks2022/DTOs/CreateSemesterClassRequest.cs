using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class CreateSemesterClassRequest
    {
        // For class
        [Required]
        public string ClassNum { get; set; } // Example GLO-1111
        [Required]
        public string Name { get; set; }

        // For semester class
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string Note { get; set; }

        // TODO:for semester schedule task
    }
}
