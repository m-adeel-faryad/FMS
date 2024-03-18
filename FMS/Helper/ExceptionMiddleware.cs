using System.Net;

namespace FMS.WebApi.Helper;
public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleGlobalExceptionAsync(context, e);
        }
    }


    private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsJsonAsync(exception.Message);
    }
}