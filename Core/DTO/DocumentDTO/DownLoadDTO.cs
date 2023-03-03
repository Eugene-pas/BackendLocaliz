namespace Core.DTO.DocumentDTO
{
    public class DownloadDTO
    {
        public byte[]? Bytes { get; set; }
        public string? NameFile { get; set; }
        public string ContentType { get; set; } = "application/octet-stream ";
    }
}
