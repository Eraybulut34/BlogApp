using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }


    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
