using System;
using System.Collections.Generic;

namespace BlogAppDomain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int UsageCount { get; set; }

    // Navigation properties
    public ICollection<PostTag> PostTags { get; set; }
} 