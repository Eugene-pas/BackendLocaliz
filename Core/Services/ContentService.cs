using AutoMapper;
using Core.DTO.ContentDTO;
using Core.Entities.ContentEntity;
using Core.Entities.DocumentEntity;
using Core.Entities.HistoryEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.APIService;
using Core.Interfaces.CustomService;
using Core.Specifications;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Services;

public class ContentService : IContentService
{
    private readonly IRepository<History> _historyRepository;
    private readonly IRepository<Content> _contentRepository;
    private readonly IRepository<Document> _documentRepository;
    private readonly ITranslationService _translationService;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public ContentService(
        UserManager<User> userManager,
        IRepository<Content> contentRepository,
        IRepository<Document> documentRepository,
        ITranslationService translationService,
        IRepository<History> historyRepository,
        IMapper mapper)
    {
        _historyRepository = historyRepository;
        _userManager = userManager;
        _contentRepository = contentRepository;
        _documentRepository = documentRepository;
        _translationService = translationService;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ContentDTO>> GetRange(ContentRangeDTO content)
    {
        var contents = await _contentRepository.ListAsync(
            new ContentSpecification.GetRange(content.DocumentId, content.PaginationFilter));

        if (contents.Count == 0)
        {
            await WriteContent(content.DocumentId);
        }

        var document =
            await _documentRepository.GetByIdAsync(content.DocumentId);



        if (document == null)
        {
            throw new HttpException("Document not found!", HttpStatusCode.NotFound);
        }

        int contentCount = await _contentRepository
            .CountAsync(new ContentSpecification.GetByDocumentId(content.DocumentId));

        int totalPages = PaginatedList<ContentDTO>
            .GetTotalPages(content.PaginationFilter, contentCount);

        return PaginatedList<ContentDTO>.Evaluate(
            _mapper.Map<List<ContentDTO>>(contents), content.PaginationFilter.PageNumber, contentCount, totalPages);
    }

    public async Task<ContentDTO> Translate(string userId, TranslateContentDTO translateContentText)
    {
        var user = await _userManager.FindByIdAsync(userId);

        ExceptionMethods.UserNullCheck(user);

        var content = await _contentRepository.GetByIdAsync(translateContentText.Id);

        if (content == null)
        {
            throw new HttpException("History not found!", HttpStatusCode.BadRequest);
        }

        if (translateContentText.Version == "")
        {
            content.Version =
                new string[] { "Beta", "Gama", "Delta", "Otta", "Sigma", "Magma" }[Random.Shared.NextInt64(0, 5)] +
                $".v{Random.Shared.NextInt64(1, 10)}";
        }
        else
        {
            content.Version = translateContentText.Version;
        }

        content.TranslateText = translateContentText.TranslateText;
        content.UserId = userId;
        content.Date = DateTimeOffset.UtcNow;

        await _historyRepository.AddAsync(new History()
        {
            TranslateText = content.TranslateText,
            Date = content.Date,
            Version = content.Version,
            Content = content,
            User = user
        });

        await _contentRepository.UpdateAsync(content);

        return _mapper.Map<ContentDTO>(content);
    }

    private async Task WriteContent(uint documentId)
    {
        var content = await _contentRepository
            .GetBySpecAsync(new ContentSpecification.GetByDocumentId(documentId));

        if (content != null)
        {
            throw new HttpException("The translate of history written", HttpStatusCode.BadRequest);
        }

        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            throw new HttpException("Not found document", HttpStatusCode.NotFound);
        }

        List<Content> contents = new List<Content>();

        string text = TransformByteToStaring(document.Data);

        Regex regex = new Regex(@"([""'])(?:(?=(\\?))\2.)*?\1(.|\n)");

        var matches = regex.Matches(text).Where(d => !d.Value.Contains(":")).ToArray();

        for (uint i = 0; i < matches.Length; i++)
        {
            contents.Add(new Content()
            {
                DocumentId = documentId,
                Text = matches[i].Value,
                Number = i + 1,
                Date = DateTimeOffset.UtcNow
            });
        }

        await _contentRepository.AddRangeAsync(contents);
    }

    public async Task TranslateAllJsonDoc(uint documentId, string from, string to)
    {
        var document = await _documentRepository
            .GetBySpecAsync(new DocumentSpecification.GetDocumentWithHistories(documentId));

        if (document == null)
        {
            throw new HttpException("Not found document", HttpStatusCode.NotFound);
        }

        var contents = document.Contents.ToArray();

        StringBuilder textForTranslation = new StringBuilder();
        List<string> textlist = new List<string>();

        for (int i = 0; i < contents.Length; i++)
        {
            if (contents[i].Text.Length > 1000)
            {
                throw new HttpException("One value in your variable is longer than 1000 characters!",
                    HttpStatusCode.BadRequest);
            }

            if (i != 0)
                textForTranslation.Append('|');

            textForTranslation.Append(contents[i].Text);

            if (textForTranslation.Length / 1000f >= 1)
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
                contents[iter].TranslateText = translateText[i];
                contents[iter].Date = DateTimeOffset.UtcNow;
                iter++;
            }
        }

        await _contentRepository.UpdateRangeAsync(contents);
    }

    private string TransformByteToStaring(byte[] data)
    {
        return Encoding.UTF8.GetString(data);
    }
}