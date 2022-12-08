using ShoShoppers.Bll.Models.Error;

namespace ShoShoppers.API.CustomMiddleware;

/// <summary>
///     Custom middleware for handling exceptions
/// </summary>
public sealed class HttpStatusCodeCustomExceptionMiddleware
{
    /// <summary>
    ///     A function that can process an HTTP request
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    ///     Logger of HttpStatusCodeCustomExceptionMiddleware to log exceptions
    /// </summary>
    private readonly ILogger<HttpStatusCodeCustomExceptionMiddleware> _logger;

    /// <summary>
    ///     Constructor for middleware
    /// </summary>
    /// <param name="next">Processing to next HTTP request</param>
    /// <param name="loggerFactory">Logger of HttpStatusCodeCustomExceptionMiddleware to log exceptions</param>
    public HttpStatusCodeCustomExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory?.CreateLogger<HttpStatusCodeCustomExceptionMiddleware>() 
            ?? throw new ArgumentNullException(nameof(loggerFactory));
    }

    /// <summary>
    ///     Handling exception in httpContext requests
    /// </summary>
    /// <param name="context">HttpContext</param>
    /// <returns>HttpContext</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (HttpStatusCodeException ex)
        {
            if (context.Response.HasStarted)
            {
                _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                throw;
            }

            _logger.LogError(ex.Message);

            await HandleExceptionAsync(context, ex);

            return;
        }
    }

    /// <summary>
    ///     Handling status code exception
    /// </summary>
    /// <param name="context">Http context</param>
    /// <param name="exception">Exception with status code and message</param>
    /// <returns>Task</returns>
    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)exception.StatusCode;
        context.Response.ContentType = exception.Message;

        await context.Response.WriteAsJsonAsync(new HttpStatusCodeErrorDetails((int)exception.StatusCode, 
            exception.Message).Serialize());
    }
}

