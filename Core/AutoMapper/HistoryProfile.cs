using AutoMapper;
using Core.DTO.HistoryDTO;
using Core.Entities.HistoryEntity;

namespace Core.AutoMapper;

public class HistoryProfile : Profile
{
    public HistoryProfile()
    {
        CreateMap<History, History>().ForMember(dest => dest.User,
            act => act.Ignore())
            .ForMember(dest => dest.UserId,
            act => act.Ignore())
            .ForMember(dest => dest.Id,
                act => act.Ignore());
        CreateMap<History, HistoryDTO>().ForMember(dest => dest.UserInfo,
            act => act.MapFrom(src => src.User));
        CreateMap<History, TranslateHistoryDTO>();
    }
}