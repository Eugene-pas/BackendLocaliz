using Core.Entities.DocumentEntity;
using Core.Entities.ProjectUserEntity;
using Core.Entities.UserEntity;

namespace Core.Entities.ProjectEntity;

public class Project
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? FinishDate { get; set; }
    public string FromTranslate { get; set; }
    public string ToTranslate { get; set; }
    public ICollection<ProjectUser> ProjectUser { get; set; }
    public ICollection<Document> Documents { get; set; }
}
