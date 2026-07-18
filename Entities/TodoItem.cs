namespace TaskFlow.API.Entities;

public class TodoItem : BaseEntity
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public bool IsCompleted { get; set; }

    public DateTime? DueDate { get; set; }

    public Guid ProjectId { get; set; }

    public Project Project { get; set; } = null!;
}