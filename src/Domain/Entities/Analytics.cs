using System;

namespace BlogAppDomain.Entities;

public class Analytics
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public int ViewCount { get; set; }
    public int UniqueViewCount { get; set; }
    public int ReadCount { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public int BookmarkCount { get; set; }
    public int ShareCount { get; set; }
    public double AverageReadTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public Post Post { get; set; }
} 