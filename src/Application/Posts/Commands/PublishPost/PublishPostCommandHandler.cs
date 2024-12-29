using System;
using System.Threading;
using System.Threading.Tasks;
using BlogAppApplication.Common.Interfaces;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Posts.Commands.PublishPost;

public class PublishPostCommandHandler : IRequestHandler<PublishPostCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public PublishPostCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<Result> Handle(PublishPostCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Result.Failure(new[] { "User not found." });

        var post = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (post == null)
            return Result.Failure(new[] { "Post not found." });

        if (post.AuthorId != userId)
            return Result.Failure(new[] { "You are not authorized to publish this post." });

        if (post.Status == PostStatus.Published)
            return Result.Failure(new[] { "Post is already published." });

        post.Status = PostStatus.Published;
        post.PublishedAt = DateTime.UtcNow;
        post.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
} 