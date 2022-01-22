namespace mchacks2022.DTOs
{
    public class UploadNoteRequest
    {
        public byte[] FileContent { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
    }
}
