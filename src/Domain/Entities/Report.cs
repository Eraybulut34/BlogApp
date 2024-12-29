using System;

namespace BlogAppDomain.Entities;

public class Report
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public Guid ReportedByUserId { get; set; }
    public Guid? PostId { get; set; }
    public Guid? CommentId { get; set; }
    public Guid? UserProfileId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public string Resolution { get; set; }

    // Navigation properties
    public User ReportedByUser { get; set; }
    public Post Post { get; set; }
    public Comment Comment { get; set; }
    public UserProfile UserProfile { get; set; }
} 