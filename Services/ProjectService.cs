using TaskFlow.API.DTOs;
using TaskFlow.API.Entities;
using TaskFlow.API.Interfaces;

namespace TaskFlow.API.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProjectResponseDto>> GetProjects(Guid userId)
    {
        var projects = await _repository.GetAllAsync(userId);

        return projects.Select(x => new ProjectResponseDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            CreatedAt = x.CreatedAt
        }).ToList();
    }

    public async Task<ProjectResponseDto> Create(Guid userId, CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description,
            UserId = userId
        };

        await _repository.CreateAsync(project);

        return new ProjectResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        };
    }
}