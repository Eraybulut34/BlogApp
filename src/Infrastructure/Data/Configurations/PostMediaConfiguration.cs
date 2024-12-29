using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAppInfrastructure.Data.Configurations;

public class PostMediaConfiguration : IEntityTypeConfiguration<PostMedia>
{
    public void Configure(EntityTypeBuilder<PostMedia> builder)
    {
        builder.HasKey(t => new { t.PostId, t.MediaId });

        builder.HasOne(t => t.Post)
            .WithMany(t => t.PostMedia)
            .HasForeignKey(t => t.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Media)
            .WithMany(t => t.PostMedia)
            .HasForeignKey(t => t.MediaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 