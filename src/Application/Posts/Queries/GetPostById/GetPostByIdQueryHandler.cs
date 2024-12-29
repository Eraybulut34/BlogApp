using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogAppApplication.Common.Interfaces;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Posts.Queries.GetPostById;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<PostDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPostByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PostDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _context.Posts
            .Include(p => p.Author)
                .ThenInclude(a => a.Profile)
            .Include(p => p.Category)
            .Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag)
            .Include(p => p.PostTopics)
                .ThenInclude(pt => pt.Topic)
            .Include(p => p.PostMedia)
                .ThenInclude(pm => pm.Media)
            .Include(p => p.Analytics)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (post == null)
            return Result<PostDto>.Failure(new[] { "Post not found." });

        var postDto = new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Slug = post.Slug,
            Content = post.Content,
            Summary = post.Summary,
            IsFeatured = post.IsFeatured,
            IsPublished = post.Status == PostStatus.Published,
            PublishedAt = post.PublishedAt,
            ReadTime = post.ReadTime,
            ViewCount = post.ViewCount,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt,
            
            Author = new AuthorDto
            {
                Id = post.Author.Id,
                Username = post.Author.Username,
                FullName = post.Author.Profile?.FullName,
                AvatarUrl = post.Author.Profile?.AvatarUrl,
                Bio = post.Author.Profile?.Bio
            },
            
            Category = post.Category == null ? null : new CategoryDto
            {
                Id = post.Category.Id,
                Name = post.Category.Name,
                Slug = post.Category.Slug
            },
            
            Tags = post.PostTags.Select(pt => new TagDto
            {
                Id = pt.Tag.Id,
                Name = pt.Tag.Name,
                Slug = pt.Tag.Slug
            }).ToList(),
            
            Topics = post.PostTopics.Select(pt => new TopicDto
            {
                Id = pt.Topic.Id,
                Name = pt.Topic.Name,
                Slug = pt.Topic.Slug,
                IconUrl = pt.Topic.IconUrl
            }).ToList(),
            
            Media = post.PostMedia.OrderBy(pm => pm.DisplayOrder).Select(pm => new MediaDto
            {
                Id = pm.Media.Id,
                Url = pm.Media.Url,
                Title = pm.Media.Title,
                Alt = pm.Media.Alt,
                DisplayOrder = pm.DisplayOrder
            }).ToList(),
            
            Analytics = post.Analytics == null ? null : new AnalyticsDto
            {
                ViewCount = post.Analytics.ViewCount,
                UniqueViewCount = post.Analytics.UniqueViewCount,
                ReadCount = post.Analytics.ReadCount,
                LikeCount = post.Analytics.LikeCount,
                CommentCount = post.Analytics.CommentCount,
                BookmarkCount = post.Analytics.BookmarkCount,
                ShareCount = post.Analytics.ShareCount,
                AverageReadTime = post.Analytics.AverageReadTime
            }
        };

        return Result<PostDto>.Success(postDto);
    }
} 