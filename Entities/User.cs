namespace TaskFlow.API.Entities;

public class User : BaseEntity
{

    public string Name { get; set; } = "";

    public string Email { get; set; } = "";

    public string PasswordHash { get; set; } = "";

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}