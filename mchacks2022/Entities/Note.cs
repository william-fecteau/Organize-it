using System;
using Microsoft.AspNetCore.Identity;

namespace mchacks2022.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }

        public string FkUserId { get; set; }
        public virtual IdentityUser FkUser { get; set; }
        
        public Guid FkSemesterClassNoteId { get; set; }
        public virtual SemesterClassNotes SemesterClassNotes { get; set; }
    }
}
