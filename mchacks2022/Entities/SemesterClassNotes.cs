using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mchacks2022.Entities
{
    public class SemesterClassNotes
    {
        [Key]
        public Guid Id { get; set; }
        public int ClassNo { get; set; } //1,2,3,4,5,6,7,8,9,10
        public string ClassSubject { get; set; }

        // From note
        //public ICollection<Note> Notes { get; set; }

        // Semester class composite keys
        public Guid FkSemesterId { get; set; }
        public virtual Semester FkSemester { get; set; }
        public Guid FkClassId { get; set; }
        public virtual Class FkClass { get; set; }
        [ForeignKey("FkSemesterId, FkClassId")]
        public virtual SemesterClass FkSemesterClass { get; set; }
    }
}
