using TaskFlow.API.Enums;

namespace TaskFlow.API.Entities
{
    public class TaskItem : BaseEntity
    {
        public Guid ProjectId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public Enums.TaskStatus Status { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public Project Project { get; set; } = null!;
    }
}
