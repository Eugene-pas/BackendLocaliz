using Core.Entities.ProjectEntity;
using Core.Entities.UserEntity;

namespace Core.Entities.ProjectUserEntity;

public class ProjectUser
{
    public uint Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public uint ProjectId { get; set; }
    public Project Project { get; set; }
}