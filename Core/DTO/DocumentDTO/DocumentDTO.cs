namespace Core.DTO.DocumentDTO;

public class DocumentDTO
{
    public uint Id { get; set; }
    public string Data { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public string? Description { get; set; }
}