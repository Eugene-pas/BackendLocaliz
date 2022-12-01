using Core.DTO;
using Core.Interfaces.CustomService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user-info")]
        public async Task<ActionResult> GetUserInfo()
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);
            var userInfo = await _userService.GetUserProfileInfoAsync(userId);
            return Ok(userInfo);
        }

        [HttpPost("edit-info")]
        public async Task<ActionResult> UserEditProfileInfo(UserEditProfileInfoDTO userEditProfileInfo)
        {
            var callbackUrl = Request.GetTypedHeaders().Referer.ToString();
            var userId = _userService.GetCurrentUserNameIdentifier(User);
            await _userService.UserEditProfileInfoAsync(userEditProfileInfo, userId, callbackUrl);
            return Ok();
        }

        [HttpGet("user-full-name")]
        public async Task<ActionResult<UserFullNameDTO>> GetUserFullName()
        {
            var userId = _userService.GetCurrentUserNameIdentifier(User);

            return Ok(await _userService.GetUserFullNameAsync(userId));
        }
    }
}
