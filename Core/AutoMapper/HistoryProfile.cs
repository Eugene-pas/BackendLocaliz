using AutoMapper;
using Core.DTO.HistoryDTO;
using Core.Entities.HistoryEntity;

namespace Core.AutoMapper;

public class HistoryProfile : Profile
{
    public HistoryProfile()
    {
        CreateMap<History, HistoryDTO>().ForMember(dest => dest.UserInfo,
            act => act.MapFrom(src => src.User)).ReverseMap();
    }
}