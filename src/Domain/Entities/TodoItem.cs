using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class TodoItem : BaseAuditableEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public int Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public TodoList List { get; set; } = null!;
}
