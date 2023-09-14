using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace SimpleLoginDemowithMiddleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {  
            string path = httpContext.Request.Path;
            string method = httpContext.Request.Method;

            StreamReader reader = new(httpContext.Request.Body);

            string body = await reader.ReadToEndAsync();

            Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
            bool containsUsername = queryDict.ContainsKey("username");
            bool containsPassword = queryDict.ContainsKey("password");
            bool containsUsernamePassword = containsPassword && containsUsername;

            Console.WriteLine($"Contains Username: {containsUsername}");
            Console.WriteLine($"Contains Password: {containsPassword}");
            if (path != "/")
            {
                httpContext.Response.StatusCode = 404;
                await httpContext.Response.WriteAsync("Not found");
            }
            else
            {
                //if(method == "GET")
                //{
                //    httpContext.Response.StatusCode=200;
                //    await httpContext.Response.WriteAsync("No Response");
                //}



                if (method == "POST")
                {
                    if(!containsUsername && !containsPassword)
                    {
                        httpContext.Response.StatusCode = 400;
                        await httpContext.Response.WriteAsync("You need to add an email and password");
                    } 
                    else if (containsUsername && !containsPassword)
                        {
                            httpContext.Response.StatusCode = 400;
                            await httpContext.Response.WriteAsync("Invalid input for 'password'");
                        }
                    else if(!containsUsername && containsPassword)
                    {
                        httpContext.Response.StatusCode = 400;
                        await httpContext.Response.WriteAsync("Invalid input for 'email'");
                    }

                    if (containsUsernamePassword)
                    {
                        string username = queryDict["username"][0];
                        string password = queryDict["password"][0];

                        bool isValidLogin = username == "admin@example.com";
                        bool isValidPassword = password == "admin1234";

                        if (isValidLogin && isValidPassword)
                        {
                            httpContext.Response.StatusCode = 200;
                            await httpContext.Response.WriteAsync("Successfully logged in");
                        }
                        else if (!isValidLogin || !isValidPassword)
                        {
                            httpContext.Response.StatusCode = 400;
                            await httpContext.Response.WriteAsync("Incorrect credentials");
                        }
                    }
                   
                   
                }
                else
                {
                    await _next(httpContext);
                }
                
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
