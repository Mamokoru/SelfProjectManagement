using System.Text.Json;
using TaskFlow.API.Exceptions;
using TaskFlow.API.Helpers;
using TaskFlow.API.Responses;

namespace TaskFlow.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning(ex.Message);

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";

            var response = ApiResponseHelper.Fail<object>(ex.Message);

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");

            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/json";

            var response = ApiResponseHelper.Fail<object>(
                "An unexpected error occurred.");

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}