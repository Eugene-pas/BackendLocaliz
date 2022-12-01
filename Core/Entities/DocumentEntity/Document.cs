using Core.Entities.HistoryEntity;
using Core.Entities.ProjectEntity;

namespace Core.Entities.DocumentEntity;

public class Document
{
    public uint Id { get; set; }
    public byte[] Data { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public string? Description { get; set; }
    public ICollection<History>? Histories { get; set; }
    public uint ProjectId { get; set; }
    public Project Project { get; set; }
}