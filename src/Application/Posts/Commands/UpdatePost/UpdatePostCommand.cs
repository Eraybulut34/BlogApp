using System;
using System.Collections.Generic;
using BlogAppApplication.Common.Models;
using MediatR;

namespace BlogAppApplication.Posts.Commands.UpdatePost;

public record UpdatePostCommand : IRequest<Result>
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string Summary { get; init; }
    public Guid? CategoryId { get; init; }
    public List<Guid> TagIds { get; init; } = new();
    public List<Guid> TopicIds { get; init; } = new();
    public List<Guid> MediaIds { get; init; } = new();
} 