using System;
using System.Threading;
using System.Threading.Tasks;
using BlogAppApplication.Common.Interfaces;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Posts.Commands.FeaturePost;

public class FeaturePostCommandHandler : IRequestHandler<FeaturePostCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public FeaturePostCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<Result> Handle(FeaturePostCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Result.Failure(new[] { "User not found." });

        var post = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (post == null)
            return Result.Failure(new[] { "Post not found." });

        if (post.AuthorId != userId)
            return Result.Failure(new[] { "You are not authorized to feature this post." });

        if (post.Status != PostStatus.Published)
            return Result.Failure(new[] { "Only published posts can be featured." });

        if (post.IsFeatured)
            return Result.Failure(new[] { "Post is already featured." });

        post.IsFeatured = true;
        post.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
} 