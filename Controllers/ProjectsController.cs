using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.DTOs;
using TaskFlow.API.Interfaces;
using TaskFlow.API.Services;

namespace TaskFlow.API.Controllers;

[ApiController]
[Authorize]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var projects = await _service.GetProjects(userId);

        return Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto dto)
    {
        var userId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var project = await _service.Create(userId, dto);

        return Ok(project);
    }
}