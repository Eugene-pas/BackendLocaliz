using System.ComponentModel.DataAnnotations;
using Core.Constants;
using Core.DTO.DocumentDTO;
using Core.Helpers;
using Core.Interfaces.CustomService;
using Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizAPI.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpPost("add")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<List<AddByteDocDTO>> AddDocument([Required, FromForm] uint projectId,
        [FromForm] List<IFormFile> documents)
    {
        return await _documentService.AddDocument(projectId, documents);
    }

    [HttpDelete]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task DeleteDocument(uint documentId)
    {
        await _documentService.DeleteDocument(documentId);
    }

    [HttpGet("all-for-user")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<List<DocumentDTO>> GetAllDocuments(uint projectId)
    {
        return await _documentService.GetAllDocuments(projectId);
    }

    [HttpGet("download")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<IActionResult> Download([FromQuery] uint documentId)
    {
        var file = await _documentService.DownloadTranslate(documentId);
        return File(file.Bytes, file.ContentType, file.NameFile);
    }
}

