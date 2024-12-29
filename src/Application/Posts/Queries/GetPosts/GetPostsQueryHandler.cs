using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogAppApplication.Common.Extensions;
using BlogAppApplication.Common.Interfaces;
using BlogAppApplication.Common.Models;
using BlogAppDomain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Posts.Queries.GetPosts;

public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, Result<PaginatedList<PostBriefDto>>>
{
    private readonly IApplicationDbContext _context;

    public GetPostsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PaginatedList<PostBriefDto>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Posts
            .Include(p => p.Author)
                .ThenInclude(a => a.Profile)
            .Include(p => p.Category)
            .Include(p => p.PostTags)
                .ThenInclude(pt => pt.Tag)
            .Include(p => p.PostMedia)
            .Include(p => p.Analytics)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(p => p.Title.ToLower().Contains(searchTerm) || 
                                   p.Content.ToLower().Contains(searchTerm) ||
                                   p.Summary.ToLower().Contains(searchTerm));
        }

        if (request.AuthorId.HasValue)
            query = query.Where(p => p.AuthorId == request.AuthorId);

        if (request.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == request.CategoryId);

        if (request.TagId.HasValue)
            query = query.Where(p => p.PostTags.Any(pt => pt.TagId == request.TagId));

        if (request.TopicId.HasValue)
            query = query.Where(p => p.PostTopics.Any(pt => pt.TopicId == request.TopicId));

        if (request.Status.HasValue)
            query = query.Where(p => p.Status == request.Status);

        if (request.IsFeatured.HasValue)
            query = query.Where(p => p.IsFeatured == request.IsFeatured);

        // Apply ordering
        query = request.OrderBy?.ToLower() switch
        {
            "createdat_asc" => query.OrderBy(p => p.CreatedAt),
            "publishedat_desc" => query.OrderByDescending(p => p.PublishedAt),
            "publishedat_asc" => query.OrderBy(p => p.PublishedAt),
            _ => query.OrderByDescending(p => p.CreatedAt)
        };

        var posts = await query
            .Select(p => new PostBriefDto
            {
                Id = p.Id,
                Title = p.Title,
                Slug = p.Slug,
                Summary = p.Summary,
                IsFeatured = p.IsFeatured,
                Status = p.Status,
                PublishedAt = p.PublishedAt,
                ReadTime = p.ReadTime,
                ViewCount = p.ViewCount,
                CreatedAt = p.CreatedAt,
                
                Author = new AuthorBriefDto
                {
                    Id = p.Author.Id,
                    Username = p.Author.Username,
                    FullName = p.Author.Profile.FullName,
                    AvatarUrl = p.Author.Profile.AvatarUrl
                },
                
                Category = p.Category == null ? null : new CategoryBriefDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Slug = p.Category.Slug
                },
                
                Tags = p.PostTags.Select(pt => new TagBriefDto
                {
                    Id = pt.Tag.Id,
                    Name = pt.Tag.Name,
                    Slug = pt.Tag.Slug
                }).ToList(),
                
                CoverImage = p.PostMedia
                    .OrderBy(pm => pm.DisplayOrder)
                    .Select(pm => pm.Media.Url)
                    .FirstOrDefault(),
                
                Statistics = new StatisticsDto
                {
                    LikeCount = p.Analytics == null ? 0 : p.Analytics.LikeCount,
                    CommentCount = p.Analytics == null ? 0 : p.Analytics.CommentCount,
                    BookmarkCount = p.Analytics == null ? 0 : p.Analytics.BookmarkCount
                }
            })
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return Result<PaginatedList<PostBriefDto>>.Success(posts);
    }
} 