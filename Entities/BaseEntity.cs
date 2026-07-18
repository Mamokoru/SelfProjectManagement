namespace TaskFlow.API.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;

        //public User CreatedBy { get; set; } = null!;

        public DateTime? UpdatedAt { get; set; }

        //public User UpdatedBy { get; set; } = null!;
    }
}
