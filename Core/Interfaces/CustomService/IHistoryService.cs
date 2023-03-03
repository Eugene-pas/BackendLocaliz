using Core.DTO.DocumentDTO;
using Core.DTO.HistoryDTO;
using Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.CustomService;

public interface IHistoryService
{
    Task<PaginatedList<HistoryDTO>> GetRange(RangeHistoryDTO history);
    Task<HistoryDTO> Translate(string userId, TranslateHistoryDTO translateHistoryText);
    Task<DownloadDTO> DownloadTranslate(uint documentId);
}