using AutoMapper;
using Core.DTO.ContentDTO;
using Core.Entities.ContentEntity;

namespace Core.AutoMapper;

public class ContentProfile : Profile
{
    public ContentProfile()
    {
        CreateMap<Content, Content>().ForMember(dest => dest.User,
            act => act.Ignore())
            .ForMember(dest => dest.UserId,
            act => act.Ignore())
            .ForMember(dest => dest.Id,
                act => act.Ignore());
        CreateMap<Content, ContentDTO>().ForMember(dest => dest.UserInfo,
            act => act.MapFrom(src => src.User)).ReverseMap();
        CreateMap<Content, TranslateContentDTO>();
    }
}