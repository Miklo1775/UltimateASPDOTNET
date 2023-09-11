using SimpleLoginDemowithMiddleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseLoginMiddleware();

app.Run(async (HttpContext context) => {

    context.Response.StatusCode = 200;
    await context.Response.WriteAsync(" No response ");

});

app.Run();
