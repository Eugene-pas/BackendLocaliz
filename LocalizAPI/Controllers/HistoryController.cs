using Core.Constants;
using Core.DTO.APIDTO;
using Core.DTO.HistoryDTO;
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
public class HistoryController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IHistoryService _historyService;
    private readonly ITranslationService _translationService;
    public HistoryController(
        IHistoryService historyService,
        IUserService userService,
        ITranslationService translationService)
    {
        _historyService = historyService;
        _userService = userService;
        _translationService = translationService;
    }

    [HttpGet("get-range")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<PaginatedList<HistoryDTO>> GetRange([FromQuery] RangeHistoryDTO history)
    {
        return await _historyService.GetRange(history);
    }

    [HttpPost("translate")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<HistoryDTO> Translate([FromBody] TranslateHistoryDTO translateHistoryText)
    {
        string userId = _userService.GetCurrentUserNameIdentifier(User);
        return await _historyService.Translate(userId, translateHistoryText);
    }

    [HttpPost("translate-document")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ActionResult> TranslateAPI([FromBody] TranslationAPIDTO translationApiDto)
    {
        await _historyService.TranslateAllJsonDoc(
            translationApiDto.DocumentId,
            translationApiDto.From,
            translationApiDto.To
            );
        return Ok();
    }
}
