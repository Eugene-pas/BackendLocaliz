using Core.DTO;
using Core.DTO.ProjectDTO;

namespace Core.Interfaces.CustomService;

public interface IProjectService
{
    Task<List<ProjectDTO>> GetAllProjectsUser(string userId);
    Task<ProjectDTO> CreateProject( string userId, ProjectCreateDTO project);
    Task<UserInfoDTO> AddUserToProject(string email, uint projectId);
}
