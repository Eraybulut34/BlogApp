using System;

namespace BlogAppDomain.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public string RedirectUrl { get; set; }
    public Guid? ActorId { get; set; }
    public Guid? PostId { get; set; }
    public Guid? CommentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ReadAt { get; set; }

    // Navigation properties
    public User User { get; set; }
    public User Actor { get; set; }
    public Post Post { get; set; }
    public Comment Comment { get; set; }
} 