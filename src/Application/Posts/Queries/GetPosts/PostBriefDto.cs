using System;
using System.Collections.Generic;
using BlogAppDomain.Enums;

namespace BlogAppApplication.Posts.Queries.GetPosts;

public class PostBriefDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Summary { get; set; }
    public bool IsFeatured { get; set; }
    public PostStatus Status { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int ReadTime { get; set; }
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public AuthorBriefDto Author { get; set; }
    public CategoryBriefDto Category { get; set; }
    public List<TagBriefDto> Tags { get; set; } = new();
    public string CoverImage { get; set; }
    public StatisticsDto Statistics { get; set; }
}

public class AuthorBriefDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string AvatarUrl { get; set; }
}

public class CategoryBriefDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}

public class TagBriefDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}

public class StatisticsDto
{
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public int BookmarkCount { get; set; }
} 