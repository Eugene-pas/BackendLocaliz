using Core.DTO.ContentDTO;
using Core.Helpers;

namespace Core.Interfaces.CustomService;

public interface IContentService
{
    Task<PaginatedList<ContentDTO>> GetRange(ContentRangeDTO content);
    Task<ContentDTO> Translate(string userId, TranslateContentDTO translateContentText);
    Task TranslateAllJsonDoc(uint documentId, string from, string to, string userId);

}
