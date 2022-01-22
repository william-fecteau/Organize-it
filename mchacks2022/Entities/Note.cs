using System;

namespace mchacks2022.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }

        public Guid FkSemesterClassNoteId { get; set; }
        public SemesterClassNotes SemesterClassNotes { get; set; }
    }
}
