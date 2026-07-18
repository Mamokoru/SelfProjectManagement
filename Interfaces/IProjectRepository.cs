using TaskFlow.API.Entities;

namespace TaskFlow.API.Interfaces;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync(Guid userId);

    Task<Project?> GetByIdAsync(Guid id, Guid userId);

    Task<Project> CreateAsync(Project project);

    Task DeleteAsync(Project project);
}