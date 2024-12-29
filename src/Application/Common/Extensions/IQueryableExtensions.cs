using System.Linq;
using System.Threading.Tasks;
using BlogAppApplication.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Common.Extensions;

public static class IQueryableExtensions
{
    public static async Task<PaginatedList<T>> PaginatedListAsync<T>(
        this IQueryable<T> queryable, int pageNumber, int pageSize)
        where T : class
    {
        var count = await queryable.CountAsync();
        var items = await queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
} 