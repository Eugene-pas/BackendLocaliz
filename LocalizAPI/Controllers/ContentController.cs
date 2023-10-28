using Core.Constants;
using Core.DTO.APIDTO;
using Core.DTO.ContentDTO;
using Core.Helpers;
using Core.Interfaces.APIService;
using Core.Interfaces.CustomService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizAPI.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IContentService _contentService;
    public ContentController(
        IContentService contentService,
        IUserService userService)
    {
        _contentService = contentService;
        _userService = userService;
    }

    [HttpGet("get-range")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<PaginatedList<ContentDTO>> GetRange([FromQuery] ContentRangeDTO content)
    {
        return await _contentService.GetRange(content);
    }

    [HttpPost("translate")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ContentDTO> Translate([FromBody] TranslateContentDTO translateContentText)
    {
        string userId = _userService.GetCurrentUserNameIdentifier(User);
        return await _contentService.Translate(userId, translateContentText);
    }

    [HttpPost("translate-document")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ActionResult> TranslateAPI([FromBody] TranslationAPIDTO translationApiDto)
    {
        string userId = _userService.GetCurrentUserNameIdentifier(User);
        await _contentService.TranslateAllJsonDoc(
            translationApiDto.DocumentId,
            translationApiDto.From,
            translationApiDto.To,
            userId
            );
        return Ok();
    }
}
