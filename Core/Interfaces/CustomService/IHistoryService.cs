using Core.DTO.HistoryDTO;
using Core.Helpers;

namespace Core.Interfaces.CustomService;

public interface IHistoryService
{
    Task<PaginatedList<HistoryDTO>> GetRange(RangeHistoryDTO history);
    Task<HistoryDTO> Translate(string userId, TranslateHistoryDTO translateHistoryText);
    Task WriteHistory(uint documentId);
}