using System.Threading;
using System.Threading.Tasks;
using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApplication.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
