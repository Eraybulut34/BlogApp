using System;

namespace BlogAppDomain.Entities;

public class Like
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? PostId { get; set; }
    public Guid? CommentId { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Post Post { get; set; }
    public Comment Comment { get; set; }
} 