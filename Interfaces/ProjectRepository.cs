using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Data;
using TaskFlow.API.Entities;
using TaskFlow.API.Interfaces;

namespace TaskFlow.API.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _db;

    public ProjectRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Project>> GetAllAsync(Guid userId)
    {
        return await _db.Projects
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(Guid id, Guid userId)
    {
        return await _db.Projects
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId);
    }

    public async Task<Project> CreateAsync(Project project)
    {
        _db.Projects.Add(project);

        await _db.SaveChangesAsync();

        return project;
    }

    public async Task DeleteAsync(Project project)
    {
        _db.Projects.Remove(project);

        await _db.SaveChangesAsync();
    }
}