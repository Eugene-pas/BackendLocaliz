using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.HistoryEntity;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder
            .Property(p => p.TranslateText)
            .IsRequired();

        builder
            .Property(p => p.Date)
            .IsRequired();

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Histories)
            .HasForeignKey(p => p.UserId);

        builder
            .HasOne(p => p.Content)
            .WithMany(p => p.Histories)
            .HasForeignKey(p => p.ContentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
