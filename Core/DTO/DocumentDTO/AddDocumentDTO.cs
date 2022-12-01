using Microsoft.AspNetCore.Http;

namespace Core.DTO.DocumentDTO;

public class AddDocumentDTO
{
    public uint? ProjectId { get; set; }
    public string NameFile { get; set; }
    public IFormFile DataFile { get; set; }
}
