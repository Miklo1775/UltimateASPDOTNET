using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareDemo.CustomMW
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    // THE PREFERRED WAY OF WRITING CUSTOM MIDDLEWARE
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //before logiv
            var queryObj = httpContext.Request.Query;

            if(queryObj.ContainsKey("firstName") && queryObj.ContainsKey("lastName"))
            {
                string name = $"Hello {queryObj["firstName"]} {queryObj["lastName"]}";
                await httpContext.Response.WriteAsync(name);
            }

             await _next(httpContext);
        
            //after logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
