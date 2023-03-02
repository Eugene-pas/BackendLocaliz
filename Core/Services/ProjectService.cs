using System.Collections.ObjectModel;
using System.Net;
using AutoMapper;
using Core.DTO;
using Core.DTO.DocumentDTO;
using Core.DTO.ProjectDTO;
using Core.Entities.DocumentEntity;
using Core.Entities.ProjectEntity;
using Core.Entities.ProjectUserEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using static Core.Specifications.ProjectUserSpecification;

namespace Core.Services;

public class ProjectService : IProjectService
{
    private readonly IDocumentService _documentService;
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<ProjectUser> _projectUserRepository;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public ProjectService(
        IRepository<Project> projectRepository,
        UserManager<User> userManager,
        IRepository<Document> documentRepository,
        IRepository<ProjectUser> projectUserRepository,
        IDocumentService documentService,
        IMapper mapper)
    {
        _projectRepository = projectRepository;
        _userManager = userManager;
        _projectUserRepository = projectUserRepository;
        _documentService = documentService;
        _mapper = mapper;
    }
    public async Task<UserInfoDTO> AddUserToProject(string email, uint projectId)
    {
        var user = await _userManager.FindByEmailAsync(email);

        ExceptionMethods.UserNullCheck(user);

        var project = await _projectRepository.GetByIdAsync(projectId);

        if (project == null)
        {
            throw new HttpException("Project not found!", HttpStatusCode.NotFound);
        }

        if (await _projectUserRepository.GetBySpecAsync(
                new ProjectUserSpecification.GetProjectByUserId(user.Id, projectId)) == null)
        {
            await _projectUserRepository.AddAsync(new ProjectUser()
            {
                User = user,
                Project = project
            });
        }
        else
        {
                throw new HttpException("The user has already been added to the project!", HttpStatusCode.Conflict);
        }


        return _mapper.Map<UserInfoDTO>(user);
    }

    public async Task<ProjectDTO> CreateProject(string userId, ProjectCreateDTO project)
    {
        var user = await _userManager.FindByIdAsync(userId);

        ExceptionMethods.UserNullCheck(user);

        var newProject = _mapper.Map<Project>(project);

        await _projectRepository.AddAsync(newProject);

        await _projectUserRepository.AddAsync(new ProjectUser()
        {
            User = user,
            Project = newProject
        });

        if(project.Documents.Count != 0)
            await _documentService.AddDocument(newProject.Id, project.Documents);

        return _mapper.Map<ProjectDTO>(newProject);
    }

    public async Task<List<ProjectDTO>> GetAllProjectsUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        ExceptionMethods.UserNullCheck(user);

        var projectUsers = await _projectUserRepository.ListAsync(
            new ProjectUserSpecification.GetProjectsByUserId(userId));

        var projects = projectUsers.Select(p => p.Project);

        return _mapper.Map<List<ProjectDTO>>(projects);
    }
}
