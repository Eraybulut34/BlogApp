using System;

namespace BlogAppDomain.Entities;

public class PostSeries
{
    public Guid PostId { get; set; }
    public Guid SeriesId { get; set; }
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Post Post { get; set; }
    public Series Series { get; set; }
} 