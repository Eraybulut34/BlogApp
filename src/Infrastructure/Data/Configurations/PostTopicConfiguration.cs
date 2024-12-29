using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAppInfrastructure.Data.Configurations;

public class PostTopicConfiguration : IEntityTypeConfiguration<PostTopic>
{
    public void Configure(EntityTypeBuilder<PostTopic> builder)
    {
        builder.HasKey(t => new { t.PostId, t.TopicId });

        builder.HasOne(t => t.Post)
            .WithMany(t => t.PostTopics)
            .HasForeignKey(t => t.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Topic)
            .WithMany(t => t.PostTopics)
            .HasForeignKey(t => t.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 