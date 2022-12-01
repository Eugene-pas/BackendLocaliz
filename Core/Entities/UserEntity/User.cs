using Core.Entities.HistoryEntity;
using Core.Entities.ProjectUserEntity;
using Core.Entities.RefreshTokenEntity;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.UserEntity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ConfirmationEmailToken { get; set; }
        public DateTimeOffset? ConfirmationEmailTokenExpirationDate { get; set; }
        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow;
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<ProjectUser> ProjectUser { get; set; }
        public ICollection<History> Histories { get; set; }
    }
}
