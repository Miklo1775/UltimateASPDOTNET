var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run( async (HttpContext context) =>
{
    string path = context.Request.Path;
    context.Response.Headers["MyKey"] = "my value";
    context.Response.Headers["Server"] = "Not Express.js";
    context.Response.Headers["Content-Type"] = "text/html";
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync($"<h2>{path}</h2>");
    await context.Response.WriteAsync("<h1>This is true</h1>");
  
});

app.Run();