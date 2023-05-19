using Core.DTO.HistoryDTO;
using Core.Helpers;

namespace Core.Interfaces.CustomService;

public interface IHistoryService
{
    Task<PaginatedList<HistoryDTO>> GetRange(HistoryRangeDTO history);
}
