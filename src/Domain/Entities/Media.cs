using System;
using System.Collections.Generic;

namespace BlogAppDomain.Entities;

public class Media
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public string MimeType { get; set; }
    public string Url { get; set; }
    public long FileSize { get; set; }
    public string Alt { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public ICollection<PostMedia> PostMedia { get; set; }
} 