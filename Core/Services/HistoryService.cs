using AutoMapper;
using Core.DTO.DocumentDTO;
using Core.DTO.HistoryDTO;
using Core.Entities.DocumentEntity;
using Core.Entities.HistoryEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text.RegularExpressions;

namespace Core.Services;

public class HistoryService : IHistoryService
{
    private readonly IRepository<History> _historyRepository;
    private readonly IRepository<Document> _documentRepository;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public HistoryService(
        UserManager<User> userManager,
        IRepository<History> historyRepository,
        IRepository<Document> documentRepository,
        IMapper mapper)
    {
        _userManager = userManager;
        _historyRepository = historyRepository;
        _documentRepository = documentRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<HistoryDTO>> GetRange(RangeHistoryDTO history)
    {
        var document =
            await _documentRepository.GetBySpecAsync(
                new DocumentSpecification.GetDocumentWithHistories(history.DocumentId));

        if (document == null)
        {
            throw new HttpException("Document not found!", HttpStatusCode.NotFound);
        }

        int historyCount = document.Histories.Count;
        int totalPages = PaginatedList<HistoryDTO>.GetTotalPages(history.PaginationFilter, historyCount);

        var histories = await _historyRepository.ListAsync(
            new HistorySpecification.GetRange(history.DocumentId, history.PaginationFilter));

        return PaginatedList<HistoryDTO>.Evaluate(
            _mapper.Map<List<HistoryDTO>>(histories), history.PaginationFilter.PageNumber, historyCount, totalPages);
    }

    public async Task<HistoryDTO> Translate(string userId, TranslateHistoryDTO translateHistoryText)
    {
        var user = await _userManager.FindByIdAsync(userId);

        ExceptionMethods.UserNullCheck(user);

        var history = await _historyRepository.GetByIdAsync(translateHistoryText.Id);

        if (history == null)
        {
            throw new HttpException("History not found!", HttpStatusCode.BadRequest);
        }

        if (translateHistoryText.Version == "")
        {
            history.Version =
                new string[] { "Beta", "Gama", "Delta", "Otta", "Sigma", "Magma" }[Random.Shared.NextInt64(0, 5)] +
                $".v{Random.Shared.NextInt64(0, 10)}";
        }
        else
        {
            history.Version = translateHistoryText.Version;
        }

        if (history.TranslateText == null)
        {
            history.TranslateText = translateHistoryText.TranslateText;
            history.UserId = userId;
            history.Date = DateTimeOffset.UtcNow;
            await _historyRepository.UpdateAsync(history);
        }
        else
        {
            var newHistory = _mapper.Map<History>(history);
            newHistory.TranslateText = translateHistoryText.TranslateText;
            newHistory.UserId = userId;
            newHistory.Date = DateTimeOffset.UtcNow;
            await _historyRepository.AddAsync(newHistory);

            return _mapper.Map<HistoryDTO>(newHistory);
        }

        return _mapper.Map<HistoryDTO>(history);
    }

    public async Task WriteHistory(uint documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            throw new HttpException("Not found document", HttpStatusCode.NotFound);
        }

        List<History> histories = new List<History>();


        var filePath = Path.GetTempFileName();
        string text = "";

        using (var fs = System.IO.File.Create(filePath))
        {
            await fs.WriteAsync(document.Data);
        }

        using (var stream = new StreamReader(filePath))
        {
            text = await stream.ReadToEndAsync();

        }

        File.Delete(filePath);

        Regex regex = new Regex(@"([""'])(?:(?=(\\?))\2.)*?\1(.|\n)");

        var matches = regex.Matches(text).Where(d => !d.Value.Contains(":")).ToArray();

        for (uint i = 0; i < matches.Length; i++)
        {
            histories.Add(new History()
            {
                DocumentId = documentId,
                Text = matches[i].Value,
                Number = i + 1
            });
        }

        await _historyRepository.AddRangeAsync(histories);
    }
}