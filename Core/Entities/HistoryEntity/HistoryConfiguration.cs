using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.HistoryEntity;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
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
            .WithMany(p => p.Histories)
            .HasForeignKey(p => p.UserId);

        builder
            .HasOne(p => p.Document)
            .WithMany(p => p.Histories)
            .HasForeignKey(p => p.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
