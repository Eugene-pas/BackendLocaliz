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
    private readonly IHistoryService _historyService;

    public HistoryController(
        IHistoryService historyService)
    {
        _historyService = historyService;
    }

    [HttpGet("get-range")]
    [AuthorizeByRole(IdentityRoleNames.User)]
    public async Task<PaginatedList<HistoryDTO>> GetRange([FromQuery] HistoryRangeDTO history)
    {
        return await _historyService.GetRange(history);
    }

}
