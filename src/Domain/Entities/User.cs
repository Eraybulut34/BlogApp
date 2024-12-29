using System;
using System.Collections.Generic;

namespace BlogAppDomain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsTwoFactorEnabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }

    // Navigation properties
    public UserProfile Profile { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Follow> Followers { get; set; }
    public ICollection<Follow> Following { get; set; }
    public ICollection<Bookmark> Bookmarks { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Newsletter> NewsletterSubscriptions { get; set; }
} 