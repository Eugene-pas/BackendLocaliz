using AutoMapper;
using Core.DTO.ContentDTO;
using Core.DTO.HistoryDTO;
using Core.Entities.ContentEntity;
using Core.Entities.HistoryEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Specifications;
using System.Net;

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

    public async Task WriteHistory(IList<Content> content, User user)
    {
        IList<History> histories = new List<History>();

        foreach (var item in content)
        {
            histories.Add(new History()
            {
                TranslateText = item.TranslateText,
                Date = item.Date,
                Version = item.Version,
                Content = item,
                User = user
            });
        }

        await _historyRepository.AddRangeAsync(histories);
    }

    public async Task WriteHistory(Content content, User user)
    {
        await _historyRepository.AddAsync(new History()
        {
            TranslateText = content.TranslateText,
            Date = content.Date,
            Version = content.Version,
            Content = content,
            User = user
        });
    }
}