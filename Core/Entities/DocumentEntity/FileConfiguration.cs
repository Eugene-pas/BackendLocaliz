using Core.Entities.UserEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.DocumentEntity;

public class FileConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.CreationDate)
            .IsRequired();

        builder
            .HasOne(p => p.Project)
            .WithMany(p => p.Documents)
            .HasForeignKey(p => p.ProjectId);

        builder
            .HasMany(p => p.Histories)
            .WithOne(p => p.Document)
            .HasForeignKey(p => p.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
