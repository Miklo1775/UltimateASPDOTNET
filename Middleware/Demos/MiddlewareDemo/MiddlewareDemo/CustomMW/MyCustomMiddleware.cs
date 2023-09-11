namespace MiddlewareDemo.CustomMW
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("This is my custom middleware - Starts\n");
            await next(context);
            await context.Response.WriteAsync("My custom middleware ends here\n");
        }
    }
    
    //CREATING EXTENSION CLASS
    public static class CustomMiddlewareExtension
    {
        //EXTENSION METHOD IS A METHOD THAT GETS INJECTED INTO A OBJECT DYNAMICALLY
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            //HERE WE ADD WHAT WE WOULD'VE ADDED TO THE PROGRAM.CS FILE
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
