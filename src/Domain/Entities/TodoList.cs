using System.Collections.Generic;
using BlogAppDomain.Common;

namespace BlogAppDomain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }


    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
