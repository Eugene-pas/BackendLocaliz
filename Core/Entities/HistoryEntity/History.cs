using Core.Entities.UserEntity;
using Core.Entities.DocumentEntity;

namespace Core.Entities.HistoryEntity;

public class History
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

}
