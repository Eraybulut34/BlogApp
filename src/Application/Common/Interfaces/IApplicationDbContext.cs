using System.Threading;
using System.Threading.Tasks;
using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<UserProfile> UserProfiles { get; }
    DbSet<Post> Posts { get; }
    DbSet<Category> Categories { get; }
    DbSet<Tag> Tags { get; }
    DbSet<PostTag> PostTags { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Like> Likes { get; }
    DbSet<Follow> Follows { get; }
    DbSet<Bookmark> Bookmarks { get; }
    DbSet<Media> Media { get; }
    DbSet<PostMedia> PostMedia { get; }
    DbSet<Series> Series { get; }
    DbSet<PostSeries> PostSeries { get; }
    DbSet<Topic> Topics { get; }
    DbSet<PostTopic> PostTopics { get; }
    DbSet<Analytics> Analytics { get; }
    DbSet<Newsletter> Newsletters { get; }
    DbSet<Report> Reports { get; }
    DbSet<Setting> Settings { get; }
    DbSet<Notification> Notifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
