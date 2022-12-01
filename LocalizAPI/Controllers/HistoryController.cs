using Core.Constants;
using Core.DTO.HistoryDTO;
using Core.Helpers;
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
    public HistoryController(
        IHistoryService historyService,
        IUserService userService)
    {
        _historyService = historyService;
        _userService = userService;
    }

    [HttpGet("get-range")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<PaginatedList<HistoryDTO>> GetRange([FromQuery] RangeHistoryDTO history)
    {
        return await _historyService.GetRange(history);
    }

    [HttpPost("translate")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<HistoryDTO> Translate(TranslateHistoryDTO translateHistoryText)
    {
        string userId = _userService.GetCurrentUserNameIdentifier(User);
        return await _historyService.Translate(userId, translateHistoryText);
    }

    [HttpPost("write")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<ActionResult> WriteHistory(uint documentId)
    {
        await _historyService.WriteHistory(documentId);
        return Ok();
    }
}