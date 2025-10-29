
using Restaurants.Domain.Exceptions;

namespace Restaurants.Api.Middleware;

public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next.Invoke(context);
		}
		catch(NotFoundException nfEx)
		{
			logger.LogWarning(nfEx, nfEx.Message);
			context.Response.StatusCode = 404;
			await context.Response.WriteAsJsonAsync(new { Error = nfEx.Message });
		}
		catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
			context.Response.StatusCode = 500;
			await context.Response.WriteAsJsonAsync(new { Error = "An unexpected error occurred." });
         
		}

    }
}
