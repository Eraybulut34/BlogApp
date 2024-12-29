using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAppInfrastructure.Data.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(t => new { t.UserId, t.RoleId });

        builder.HasOne(t => t.User)
            .WithMany(t => t.UserRoles)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Role)
            .WithMany(t => t.UserRoles)
            .HasForeignKey(t => t.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 