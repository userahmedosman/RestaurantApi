
using System.Diagnostics;

namespace Restaurants.Api.Middleware;

public class RequestTimeMeasureMiddleware(ILogger<RequestTimeMeasureMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();   
        await next(context);
        stopwatch.Stop();

        if(stopwatch.ElapsedMilliseconds / 1000 > 4)
        {
            logger.LogWarning("Request [{Method}] {Url} took {ElapsedSeconds} seconds", 
                context.Request.Method,
                context.Request.Path,
                stopwatch.ElapsedMilliseconds / 1000);
        }
    }
}
