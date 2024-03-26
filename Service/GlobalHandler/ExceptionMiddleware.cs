using System;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http; 
 
namespace Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next; 
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            { 
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ApiResponse()
            {
                Id=exception.Source,
                Status = context.Response.StatusCode.ToString(),
                Message = exception.Message,
                StackTrace=exception.StackTrace,
                Success=false,//"Internal Server Error from the custom middleware."
                Data=null

            }.ToString());
        }
    }
}
