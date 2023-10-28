using Core.DTO.HistoryDTO;
using Core.Entities.ContentEntity;
using Core.Entities.UserEntity;
using Core.Helpers;

namespace Core.Interfaces.CustomService;

public interface IHistoryService
{
    Task<PaginatedList<HistoryDTO>> GetRange(HistoryRangeDTO history);
    Task WriteHistory(IList<Content> content, User user);
    Task WriteHistory(Content content, User user);

}
