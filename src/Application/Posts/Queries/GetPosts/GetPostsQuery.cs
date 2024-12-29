using System;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Enums;
using MediatR;

namespace BlogAppApplication.Posts.Queries.GetPosts;

public record GetPostsQuery : IRequest<Result<PaginatedList<PostBriefDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? SearchTerm { get; init; }
    public Guid? AuthorId { get; init; }
    public Guid? CategoryId { get; init; }
    public Guid? TagId { get; init; }
    public Guid? TopicId { get; init; }
    public PostStatus? Status { get; init; }
    public bool? IsFeatured { get; init; }
    public string? OrderBy { get; init; } = "createdAt_desc"; // createdAt_desc, createdAt_asc, publishedAt_desc, publishedAt_asc
} 