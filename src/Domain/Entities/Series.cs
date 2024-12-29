using System;
using System.Collections.Generic;

namespace BlogAppDomain.Entities;

public class Series
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public ICollection<PostSeries> PostSeries { get; set; }
} 