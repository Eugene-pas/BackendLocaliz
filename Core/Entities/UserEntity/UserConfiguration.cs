using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities.UserEntity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(p => p.ProjectUser)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder
                .HasMany(p => p.Histories)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder
                .HasMany(p => p.Contents)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder
                .HasMany(p => p.RefreshTokens)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
