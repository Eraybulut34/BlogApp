using System;
using System.Collections.Generic;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Enums;
using MediatR;

namespace BlogAppApplication.Posts.Commands.CreatePost;

public record CreatePostCommand : IRequest<Result<Guid>>
{
    public string Title { get; init; }
    public string Content { get; init; }
    public string Summary { get; init; }
    public Guid? CategoryId { get; init; }
    public List<Guid> TagIds { get; init; } = new();
    public List<Guid> TopicIds { get; init; } = new();
    public List<Guid> MediaIds { get; init; } = new();
    public PostStatus Status { get; init; }
    public bool IsFeatured { get; init; }
} 