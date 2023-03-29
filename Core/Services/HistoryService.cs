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
using System.Text;
using System.Text.RegularExpressions;
using Core.Interfaces.APIService;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Core.Services;

public class HistoryService : IHistoryService
{
    private readonly IRepository<History> _historyRepository;
    private readonly IRepository<Document> _documentRepository;
    private readonly ITranslationService _translationService;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public HistoryService(
        UserManager<User> userManager,
        IRepository<History> historyRepository,
        IRepository<Document> documentRepository,
        ITranslationService translationService,
        IMapper mapper)
    {
        _userManager = userManager;
        _historyRepository = historyRepository;
        _documentRepository = documentRepository;
        _translationService = translationService;
        _mapper = mapper;
    }

    public async Task<PaginatedList<HistoryDTO>> GetRange(RangeHistoryDTO history)
    {
        var histories = await _historyRepository.ListAsync(
            new HistorySpecification.GetRange(history.DocumentId, history.PaginationFilter));

        if (histories.Count == 0)
        {
            await WriteHistory(history.DocumentId);
        }

        var document =
            await _documentRepository.GetByIdAsync(history.DocumentId);



        if (document == null)
        {
            throw new HttpException("Document not found!", HttpStatusCode.NotFound);
        }

        int historyCount = await _historyRepository
            .CountAsync(new HistorySpecification.GetByDocumentId(history.DocumentId));

        int totalPages = PaginatedList<HistoryDTO>
            .GetTotalPages(history.PaginationFilter, historyCount);

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
                $".v{Random.Shared.NextInt64(1, 10)}";
        }
        else
        {
            history.Version = translateHistoryText.Version;
        }


        history.TranslateText = translateHistoryText.TranslateText;
        history.UserId = userId;
        history.Date = DateTimeOffset.UtcNow;
        await _historyRepository.UpdateAsync(history);

        // Create new history when TranslateText is equal to existing value
        //
        //else
        //{
        //    var newHistory = _mapper.Map<History>(history);
        //    newHistory.TranslateText = translateHistoryText.TranslateText;
        //    newHistory.UserId = userId;
        //    newHistory.Date = DateTimeOffset.UtcNow;
        //    await _historyRepository.AddAsync(newHistory);

        //    return _mapper.Map<HistoryDTO>(newHistory);
        //}



        return _mapper.Map<HistoryDTO>(history);
    }

    private async Task WriteHistory(uint documentId)
    {
        var history = await _historyRepository
            .GetBySpecAsync(new HistorySpecification.GetByDocumentId(documentId));

        if (history != null)
        {
            throw new HttpException("The translate of history written", HttpStatusCode.BadRequest);
        }

        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            throw new HttpException("Not found document", HttpStatusCode.NotFound);
        }

        List<History> histories = new List<History>();

        string text = TransformByteToStaring(document.Data);

        Regex regex = new Regex(@"([""'])(?:(?=(\\?))\2.)*?\1(.|\n)");

        var matches = regex.Matches(text).Where(d => !d.Value.Contains(":")).ToArray();

        for (uint i = 0; i < matches.Length; i++)
        {
            histories.Add(new History()
            {
                DocumentId = documentId,
                Text = matches[i].Value,
                Number = i + 1,
                Date = DateTimeOffset.UtcNow
            });
        }

        await _historyRepository.AddRangeAsync(histories);
    }

    public async Task TranslateAllJsonDoc(uint documentId, string from, string to)
    {
        var document = await _documentRepository
            .GetBySpecAsync(new DocumentSpecification.GetDocumentWithHistories(documentId));

        if (document == null)
        {
            throw new HttpException("Not found document", HttpStatusCode.NotFound);
        }

        var histories = document.Histories.ToArray();

        StringBuilder textForTranslation = new StringBuilder();
        List<string> textlist = new List<string>();

        for (int i = 0; i < histories.Length; i++)
        {
            if (histories[i].Text.Length > 1000)
            {
                throw new HttpException("One value in your variable is longer than 1000 characters!",
                    HttpStatusCode.BadRequest);
            }

            if(i != 0)
                textForTranslation.Append('|');

            textForTranslation.Append(histories[i].Text);

            if(textForTranslation.Length / 1000f >= 1 )
            {
                textlist.Add(
                    await _translationService
                    .SearchTranslation(textForTranslation.ToString(), from, to)
                    );
                textForTranslation.Clear();
            }
        }

        textlist.Add(
            await _translationService
            .SearchTranslation(textForTranslation.ToString(), from, to)
            );
        textForTranslation.Clear();

        int iter = 0;
        foreach (var text in textlist)
        {
            var translateText = text.Split('|');
            for (int i = 0; i < translateText.Length; i++)
            {
                histories[iter].TranslateText = translateText[i];
                histories[iter].Date = DateTimeOffset.UtcNow;
                iter++;
            }
        }

        await _historyRepository.UpdateRangeAsync(histories);
    }

    private string TransformByteToStaring(byte[] data)
    {
        return Encoding.UTF8.GetString(data);
    }
}
