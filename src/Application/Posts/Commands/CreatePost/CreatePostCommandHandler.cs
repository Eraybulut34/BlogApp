using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BlogAppApplication.Common.Interfaces;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Entities;
using BlogAppDomain.Enums;
using MediatR;

namespace BlogAppApplication.Posts.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public CreatePostCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<Result<Guid>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        if (userId == null)
            return Result<Guid>.Failure(new[] { "User not found." });

        var post = new Post
        {
            Title = request.Title,
            Slug = GenerateSlug(request.Title),
            Content = request.Content,
            Summary = request.Summary,
            CategoryId = request.CategoryId,
            AuthorId = userId.Value,
            IsFeatured = request.IsFeatured,
            Status = request.Status,
            PublishedAt = request.Status == PostStatus.Published ? DateTime.UtcNow : null,
            CreatedAt = DateTime.UtcNow
        };

        _context.Posts.Add(post);

        if (request.TagIds.Any())
        {
            foreach (var tagId in request.TagIds)
            {
                post.PostTags.Add(new PostTag
                {
                    PostId = post.Id,
                    TagId = tagId,
                    CreatedAt = DateTime.UtcNow
                });
            }
        }

        if (request.TopicIds.Any())
        {
            foreach (var topicId in request.TopicIds)
            {
                post.PostTopics.Add(new PostTopic
                {
                    PostId = post.Id,
                    TopicId = topicId,
                    CreatedAt = DateTime.UtcNow
                });
            }
        }

        if (request.MediaIds.Any())
        {
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
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(post.Id);
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