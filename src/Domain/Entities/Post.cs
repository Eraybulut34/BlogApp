using System;
using System.Collections.Generic;
using BlogAppDomain.Enums;

namespace BlogAppDomain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Summary { get; set; }
    public string Content { get; set; }
    public bool IsFeatured { get; set; }
    public PostStatus Status { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ReadTime { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid AuthorId { get; set; }
    public Guid? CategoryId { get; set; }

    // Navigation properties
    public User Author { get; set; }
    public Category Category { get; set; }
    public ICollection<PostTag> PostTags { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Bookmark> Bookmarks { get; set; }
    public ICollection<PostMedia> PostMedia { get; set; }
    public ICollection<PostSeries> PostSeries { get; set; }
    public ICollection<PostTopic> PostTopics { get; set; }
    public Analytics Analytics { get; set; }
} 