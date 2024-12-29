using System;
using System.Collections.Generic;

namespace BlogAppDomain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public bool IsEdited { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentCommentId { get; set; }

    // Navigation properties
    public Post Post { get; set; }
    public User User { get; set; }
    public Comment ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; }
    public ICollection<Like> Likes { get; set; }
} 