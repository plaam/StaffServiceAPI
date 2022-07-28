using System.Net;
using System.Text.Json;
using StaffServiceAPI.Dto;

namespace StaffServiceAPI.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;


    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (KeyNotFoundException e)
        {
            await HandleExceptionAsync(httpContext, 
                e.Message, 
                HttpStatusCode.NotFound, 
                "Joe wasn't found");
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext,
                e.Message,
                HttpStatusCode.InternalServerError,
                "Internal server error.");
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, string e, HttpStatusCode httpStatusCode, string msg)
    {
        _logger.LogError(e);
        var response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;

        ErrorDto errorDto = new()
        {
            Message = msg, StatusCode = (int) httpStatusCode
        };

        await response.WriteAsJsonAsync(JsonSerializer.Serialize(errorDto));
    }
}