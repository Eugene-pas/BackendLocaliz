using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.ProjectEntity;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.CreationDate)
            .IsRequired();

        builder
            .HasMany(p => p.Documents)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);

        builder
            .HasMany(p => p.ProjectUser)
            .WithOne(p => p.Project)
            .HasForeignKey(p => p.ProjectId);
    }
}
