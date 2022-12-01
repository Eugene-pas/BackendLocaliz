using Core.DTO.DocumentDTO;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.CustomService;

public interface IDocumentService
{
    Task<List<AddByteDocDTO>> AddDocument(uint projectId, List<IFormFile> documents);
    Task<List<DocumentDTO>> GetAllDocuments(uint projectId);
    Task DeleteDocument(uint documentId);
}
