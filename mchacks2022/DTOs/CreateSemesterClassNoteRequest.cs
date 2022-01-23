using System.ComponentModel.DataAnnotations;

namespace mchacks2022.DTOs
{
    public class CreateSemesterClassNoteRequest
    {
        [Required]
        public int ClassNo { get; set; } //1,2,3,4,5,6,7,8,9,10
        [Required]
        public string ClassSubject { get; set; }
    }
}
