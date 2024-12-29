using System.Reflection;
using BlogAppApplication.Common.Interfaces;
using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppInfrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<PostTag> PostTags => Set<PostTag>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Follow> Follows => Set<Follow>();
    public DbSet<Bookmark> Bookmarks => Set<Bookmark>();
    public DbSet<Media> Media => Set<Media>();
    public DbSet<PostMedia> PostMedia => Set<PostMedia>();
    public DbSet<Series> Series => Set<Series>();
    public DbSet<PostSeries> PostSeries => Set<PostSeries>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<PostTopic> PostTopics => Set<PostTopic>();
    public DbSet<Analytics> Analytics => Set<Analytics>();
    public DbSet<Newsletter> Newsletters => Set<Newsletter>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
} 