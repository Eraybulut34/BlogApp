using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAppInfrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(t => t.Username)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.PasswordHash)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Salt)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(t => t.Username)
            .IsUnique();

        builder.HasIndex(t => t.Email)
            .IsUnique();

        builder.HasMany(u => u.Notifications)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<Notification>()
            .WithOne(n => n.Actor)
            .HasForeignKey(n => n.ActorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
} 