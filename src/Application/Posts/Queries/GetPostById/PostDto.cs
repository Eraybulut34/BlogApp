using System;
using System.Collections.Generic;

namespace BlogAppApplication.Posts.Queries.GetPostById;

public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Content { get; set; }
    public string Summary { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ReadTime { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public AuthorDto Author { get; set; }
    public CategoryDto Category { get; set; }
    public List<TagDto> Tags { get; set; } = new();
    public List<TopicDto> Topics { get; set; } = new();
    public List<MediaDto> Media { get; set; } = new();
    public AnalyticsDto Analytics { get; set; }
}

public class AuthorDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string AvatarUrl { get; set; }
    public string Bio { get; set; }
}

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}

public class TagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}

public class TopicDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string IconUrl { get; set; }
}

public class MediaDto
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string Alt { get; set; }
    public int DisplayOrder { get; set; }
}

public class AnalyticsDto
{
    public int ViewCount { get; set; }
    public int UniqueViewCount { get; set; }
    public int ReadCount { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public int BookmarkCount { get; set; }
    public int ShareCount { get; set; }
    public double AverageReadTime { get; set; }
} 