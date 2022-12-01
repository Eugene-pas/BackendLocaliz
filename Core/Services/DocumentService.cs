using System.Net;
using AutoMapper;
using Core.DTO.DocumentDTO;
using Core.Entities.DocumentEntity;
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
                var documentPath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(documentPath))
                {
                    await document.CopyToAsync(stream);

                    var st = document.OpenReadStream();
                    using (var br = new BinaryReader(st))
                    {
                        bytes = br.ReadBytes((int)stream.Length);
                    }
                }
                System.IO.File.Delete(documentPath);
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
            throw new HttpException("Not found document!", HttpStatusCode.BadRequest);
        }

        await _documentRepository.DeleteAsync(document);
    }

    public async Task<List<DocumentDTO>> GetAllDocuments(uint projectId)
    {
        var project = await _projectRepository.GetByIdAsync(projectId);

        if (project == null)
        {
            throw new HttpException("Not found project!", HttpStatusCode.BadRequest);
        }

        var documents = await _documentRepository.ListAsync(
            new DocumentSpecification.GetDocumentByProjectId(projectId));

        return _mapper.Map<List<DocumentDTO>>(documents);
    }
}