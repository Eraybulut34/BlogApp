using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BlogAppApplication.Common.Interfaces;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Result>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public UpdatePostCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Result.Failure(new[] { "User not found." });

        var post = await _context.Posts
            .Include(p => p.PostTags)
            .Include(p => p.PostTopics)
            .Include(p => p.PostMedia)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (post == null)
            return Result.Failure(new[] { "Post not found." });

        if (post.AuthorId != userId)
            return Result.Failure(new[] { "You are not authorized to update this post." });

        post.Title = request.Title;
        post.Slug = GenerateSlug(request.Title);
        post.Content = request.Content;
        post.Summary = request.Summary;
        post.CategoryId = request.CategoryId;
        post.UpdatedAt = DateTime.UtcNow;

        // Update tags
        post.PostTags.Clear();
        foreach (var tagId in request.TagIds)
        {
            post.PostTags.Add(new PostTag
            {
                PostId = post.Id,
                TagId = tagId,
                CreatedAt = DateTime.UtcNow
            });
        }

        // Update topics
        post.PostTopics.Clear();
        foreach (var topicId in request.TopicIds)
        {
            post.PostTopics.Add(new PostTopic
            {
                PostId = post.Id,
                TopicId = topicId,
                CreatedAt = DateTime.UtcNow
            });
        }

        // Update media
        post.PostMedia.Clear();
        var order = 0;
        foreach (var mediaId in request.MediaIds)
        {
            post.PostMedia.Add(new PostMedia
            {
                PostId = post.Id,
                MediaId = mediaId,
                DisplayOrder = order++,
                CreatedAt = DateTime.UtcNow
            });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private static string GenerateSlug(string title)
    {
        string str = title.ToLowerInvariant();
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        str = Regex.Replace(str, @"\s+", " ").Trim();
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", "-");
        return str;
    }
} 