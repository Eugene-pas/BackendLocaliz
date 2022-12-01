using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities.ProjectUserEntity;

public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
{
    public void Configure(EntityTypeBuilder<ProjectUser> builder)
    {
        builder.HasOne(p => p.Project)
            .WithMany(p => p.ProjectUser)
            .HasForeignKey(p => p.ProjectId);

        builder.HasOne(p => p.User)
            .WithMany(p => p.ProjectUser)
            .HasForeignKey(p => p.UserId);
    }
}