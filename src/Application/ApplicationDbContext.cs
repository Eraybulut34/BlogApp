using BlogAppApplication.Common.Interfaces;
using BlogAppDomain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet tanımları
    public DbSet<TodoList> TodoLists { get; set; }
    
    public DbSet<TodoItem> TodoItems { get; set; }
    
}
