using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Data;
using TaskFlow.API.DTOs;
using TaskFlow.API.Entities;
using TaskFlow.API.Services;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly JwtService _jwtService;

    public AuthController(
        ApplicationDbContext db,
        JwtService jwtService)
    {
        _db = db;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        if (_db.Users.Any(x => x.Email == request.Email))
        {
            return BadRequest("Email already exists");
        }

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _db.Users.Add(user);
        _db.SaveChanges();

        return Ok("User created");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = _db.Users.FirstOrDefault(
            x => x.Email == request.Email);

        if (user == null)
        {
            return Unauthorized();
        }

        var valid =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!valid)
        {
            return Unauthorized();
        }

        var token =
            _jwtService.GenerateToken(user);

        return Ok(new
        {
            token
        });
    }
    [HttpGet("test-error")]
    public IActionResult TestError()
    {
        throw new Exception("This is a test exception.");
    }
}

