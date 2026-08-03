using TaskFlow.API.DTOs;

namespace TaskFlow.API.Interfaces
{
    public interface IProjectService
    {
        public Task<ProjectResponseDto> Create(Guid userId, CreateProjectDto dto);
        public Task<List<ProjectResponseDto>> GetProjects(Guid userId);
    }
}
