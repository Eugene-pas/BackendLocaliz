using Core.Entities.HistoryEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities.ContentEntity;

public class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder
            .Property(p => p.Text)
            .IsRequired();

        builder
            .Property(p => p.Date)
            .IsRequired();

        builder
            .Property(p => p.Number)
            .IsRequired();

        builder.Property(p => p.DocumentId)
            .IsRequired(false);

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Contents)
            .HasForeignKey(p => p.UserId);

        builder
            .HasOne(p => p.Document)
            .WithMany(p => p.Contents)
            .HasForeignKey(p => p.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}