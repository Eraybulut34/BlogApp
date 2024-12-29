using System;

namespace BlogAppDomain.Entities;

public class PostTopic
{
    public Guid PostId { get; set; }
    public Guid TopicId { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Post Post { get; set; }
    public Topic Topic { get; set; }
} 