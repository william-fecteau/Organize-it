namespace mchacks2022.DTOs
{
    public class UploadNoteRequest
    {
        public int[] FileContent { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
    }
}
