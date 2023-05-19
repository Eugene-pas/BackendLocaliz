using AutoMapper;
using Core.Entities.HistoryEntity;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.DTO.HistoryDTO;
using Core.DTO.ContentDTO;
using Core.Exceptions;
using Core.Specifications;
using System.Net;
using Core.Entities.ContentEntity;

namespace Core.Services;

public class HistoryService : IHistoryService
{
    private readonly IRepository<History> _historyRepository;
    private readonly IRepository<Content> _contentRepository;
    private readonly IMapper _mapper;
    public HistoryService(
        IRepository<History> historyRepository,
        IRepository<Content> contentRepository,
        IMapper mapper)
    {
        _historyRepository = historyRepository;
        _contentRepository = contentRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<HistoryDTO>> GetRange(HistoryRangeDTO history)
    {
        var content =
            await _contentRepository.GetByIdAsync(history.ContentId);

        if (content == null)
        {
            throw new HttpException("Content not found!", HttpStatusCode.NotFound);
        }

        var histories = await _historyRepository.ListAsync(
            new HistoriesSpecification.GetRange(history.ContentId, history.PaginationFilter));

        int historyCount = await _historyRepository
            .CountAsync(new HistoriesSpecification.GetByContentId(history.ContentId));

        int totalPages = PaginatedList<ContentDTO>
            .GetTotalPages(history.PaginationFilter, historyCount);

        return PaginatedList<HistoryDTO>.Evaluate(
            _mapper.Map<List<HistoryDTO>>(histories), history.PaginationFilter.PageNumber, historyCount, totalPages);
    }
}
