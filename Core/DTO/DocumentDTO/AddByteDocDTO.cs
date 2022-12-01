using Microsoft.AspNetCore.Http;

namespace Core.DTO.DocumentDTO;

public class AddByteDocDTO
{
    public uint? ProjectId { get; set; }
    public string NameFile { get; set; }
    public byte[] DataFile { get; set; }
}