using AutoMapper;
using Core.DTO.DocumentDTO;
using Core.Entities.DocumentEntity;

namespace Core.AutoMapper;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Document, AddDocumentDTO>()
            .ForMember(dest => dest.NameFile,
                act => act.MapFrom(src => src.Name))
            .ReverseMap();
        CreateMap<Document, AddByteDocDTO>().ForMember(dest => dest.DataFile,
                act => act.MapFrom(src => src.Data))
            .ForMember(dest => dest.NameFile,
                act => act.MapFrom(src => src.Name))
            .ReverseMap();
        CreateMap<Document, DocumentDTO>();
    }
}
