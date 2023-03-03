using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using AutoMapper;
using Core.DTO.DocumentDTO;
using Core.Entities.DocumentEntity;
using Core.Entities.HistoryEntity;
using Core.Entities.ProjectEntity;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomService;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Core.Services;

public class DocumentService : IDocumentService
{
    private readonly IRepository<Project> _projectRepository;
    private readonly IRepository<Document> _documentRepository;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public DocumentService(
        IRepository<Document> documentRepository, 
        UserManager<User> userManager,
        IRepository<Project> projectRepository,
        IMapper mapper)
    {
        _documentRepository = documentRepository;
        _userManager = userManager;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    public async Task<List<AddByteDocDTO>> AddDocument(uint projectId, List<IFormFile> documents)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);

        if (project == null)
        {
            throw new HttpException("Not found project!", HttpStatusCode.NotFound);
        }


        if (documents == null)
        {
            throw new HttpException("Not found documents!", HttpStatusCode.BadRequest);
        }

        var newDocuments = new List<AddByteDocDTO>();

        byte[] bytes = Array.Empty<byte>();

        foreach (var document in documents)
        {
            if (document.Length > 0)
            {
                using (var st = document.OpenReadStream())
                {
                    using (var br = new BinaryReader(st))
                    {
                        bytes = br.ReadBytes((int)st.Length);
                    }
                }
            }
            newDocuments.Add(new AddByteDocDTO()
            {
                ProjectId = projectId,
                NameFile = document.FileName,
                DataFile = bytes
            });
        }

        await _documentRepository.AddRangeAsync(
            _mapper.Map<List<Document>>(newDocuments));

        return newDocuments;
    }

    public async Task DeleteDocument(uint documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);

        if (document == null)
        {
            throw new HttpException("Not found document!", HttpStatusCode.NotFound);
        }

        await _documentRepository.DeleteAsync(document);
    }

    public async Task<List<DocumentDTO>> GetAllDocuments(uint projectId)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);

        if (project == null)
        {
            throw new HttpException("Not found project!", HttpStatusCode.NotFound);
        }

        var documents = await _documentRepository.ListAsync(
            new DocumentSpecification.GetDocumentByProjectId(projectId));

        return _mapper.Map<List<DocumentDTO>>(documents);
    }

    public async Task<DownloadDTO> DownloadTranslate(uint documentId)
    {
        var document =
            await _documentRepository.GetBySpecAsync(
                new DocumentSpecification.GetDocumentWithHistories(documentId));

        if (document == null)
        {
            throw new HttpException("Not found document", HttpStatusCode.NotFound);
        }

        if (document.Histories == null)
        {
            throw new HttpException("The translate of history written", HttpStatusCode.BadRequest);
        }

        var dataFile = TransformByteToStaring(document.Data);

        foreach (var history in document.Histories)
        {
            if (history.TranslateText == null)
                continue;

            dataFile = Regex.Replace(dataFile, history.Text, history.TranslateText);
        }

        byte[] bytes = Encoding.UTF8.GetBytes(dataFile);

        return new DownloadDTO()
        {
            Bytes = bytes,
            NameFile = document.Name
        };
    }

    private string TransformByteToStaring(byte[] data)
    {
        return Encoding.UTF8.GetString(data);
    }
}