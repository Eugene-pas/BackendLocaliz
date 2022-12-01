using Core.Entities.RefreshTokenEntity;
using Core.Entities.UserEntity;
using Core.Resources;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text;

namespace Core.Exceptions
{
    public static class ExceptionMethods
    {
        public static void UserNullCheck(User user)
        {
            if (user == null)
            {
                throw new HttpException(
                    ErrorMessages.UserNotFound,
                    HttpStatusCode.NotFound);
            }
        }

        public static void IdentityRoleNullCheck(IdentityRole role)
        {
            if (role == null)
            {
                throw new HttpException(
                    ErrorMessages.RoleNotFound,
                    HttpStatusCode.NotFound);
            }
        }

        public static void RefreshTokenNullCheck(RefreshToken refreshToken)
        {
            if (refreshToken == null)
            {
                throw new HttpException(
                    ErrorMessages.InvalidToken,
                    HttpStatusCode.NotFound);
            }
        }

        public static void CheckIdentityResult(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                var messageBuilder = new StringBuilder();

                foreach (var error in identityResult.Errors)
                {
                    messageBuilder.AppendLine(error.Description);
                }

                throw new HttpException(messageBuilder.ToString(), HttpStatusCode.BadRequest);
            }
        }
    }
}
