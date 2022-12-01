using AutoMapper;
using Core.DTO.ProjectDTO;
using Core.Entities.ProjectEntity;

namespace Core.AutoMapper;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectCreateDTO>().ReverseMap();
        CreateMap<Project, ProjectDTO>();
    }
}
