using System;

namespace BlogAppDomain.Entities;

public class PostMedia
{
    public Guid PostId { get; set; }
    public Guid MediaId { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Post Post { get; set; }
    public Media Media { get; set; }
} 