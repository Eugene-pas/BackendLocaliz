using Core.Entities.UserEntity;
using Core.Entities.DocumentEntity;
using Core.Entities.HistoryEntity;

namespace Core.Entities.ContentEntity;

public class Content
{
    public uint Id { get; set; }
    public string Text { get; set; }
    public string? TranslateText { get; set; }
    public DateTimeOffset Date { get; set; }
    public string? Version { get; set; }
    public uint Number { get; set; }
    public uint? DocumentId { get; set; }
    public Document? Document { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public ICollection<History>? Histories { get; set; }
}