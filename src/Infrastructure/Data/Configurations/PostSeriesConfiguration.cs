using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAppInfrastructure.Data.Configurations;

public class PostSeriesConfiguration : IEntityTypeConfiguration<PostSeries>
{
    public void Configure(EntityTypeBuilder<PostSeries> builder)
    {
        builder.HasKey(t => new { t.PostId, t.SeriesId });

        builder.HasOne(t => t.Post)
            .WithMany(t => t.PostSeries)
            .HasForeignKey(t => t.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Series)
            .WithMany(t => t.PostSeries)
            .HasForeignKey(t => t.SeriesId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 