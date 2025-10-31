using System.Net;
using System.Text.Json;

namespace BackendForBeginners_Net10_Solution;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // This is letting function to go to the next middleware or controller at the end of the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // If an exception occurred - handle it here
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        // Set response status code and content type
        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        context.Response.ContentType = "application/json";

        // Prepare response body
        var result = JsonSerializer.Serialize(new
        {
            Error = "Something went wrong",
            ex.Message
        });

        return context.Response.WriteAsync(result);
    }
}