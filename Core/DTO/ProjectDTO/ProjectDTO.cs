namespace Core.DTO.ProjectDTO;

public class ProjectDTO
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset FinishDate { get; set; }
    public string FromTranslate { get; set; }
    public string ToTranslate { get; set; }
}
