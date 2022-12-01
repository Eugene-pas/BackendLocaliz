using Microsoft.AspNetCore.Http;

namespace Core.DTO.ProjectDTO;

public class ProjectCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset FinishDate { get; set; }
    public string FromTranslate { get; set; }
    public string ToTranslate { get; set; }
    public List<IFormFile> Documents { get; set; }
}
