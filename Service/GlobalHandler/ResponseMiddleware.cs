using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Api.Service.GlobalHandler
{
    public class ResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // Call the next middleware in the pipeline
                await next(context);
            }
            catch (Exception ex)
            {
                // Handle exceptions and format as ApiResponse
                var response = new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                    Status = "error",
                    StackTrace = ex.StackTrace
                };
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}

