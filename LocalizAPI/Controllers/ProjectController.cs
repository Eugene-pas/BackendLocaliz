using Core.Constants;
using Core.DTO;
using Core.DTO.ProjectDTO;
using Core.Helpers;
using Core.Interfaces.CustomService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizAPI.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IProjectService _projectService;
    public ProjectController(
        IUserService userService,
        IProjectService projectService)
    {
        _userService = userService;
        _projectService = projectService;
    }

    [HttpPost("add-user")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ActionResult<UserInfoDTO>> AddUserToProject(string email, uint projectId)
    {
        return await _projectService.AddUserToProject(email, projectId);
    }

    [HttpPost("create")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ActionResult<ProjectDTO>> CreateProject([FromBody] ProjectCreateDTO project)
    {
        var userId = _userService.GetCurrentUserNameIdentifier(User);
        return await _projectService.CreateProject(userId, project);
    }

    [HttpGet("all-for-user")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ActionResult<List<ProjectDTO>>> GetAllProjectsUser()
    {
        var userId = _userService.GetCurrentUserNameIdentifier(User);
        return await _projectService.GetAllProjectsUser(userId);
    }
}