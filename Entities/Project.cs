namespace TaskFlow.API.Entities;

public class Project : BaseEntity
{
    
    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public ICollection<TodoItem> Tasks { get; set; }
    = new List<TodoItem>();
}