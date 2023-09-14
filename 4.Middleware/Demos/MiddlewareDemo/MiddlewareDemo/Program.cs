using MiddlewareDemo.CustomMW;

var builder = WebApplication.CreateBuilder(args);

//  ADDING CUSTOM MIDDLEWARE AS A SERVICE
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

//THIS MIDDLEWARE CAN RECEIVE AN OBJECT OF HttpContext
//THE LAMBDA EXPRESSION HERE CAN TECHNICALLY BE CALLED REQUEST DELEGATE
//app.Run() DOESN'T FORWARD THE REQUEST TO THE NEXT MIDDLEWARE
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello World");
//});

//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Goodbye World");
//});

//app.Use() CAN FORWARD THE NEXT MIDDLEWARE IN THE CHAIN
//IT TAKES 2 ARGUMENTS--HttpContext context and RequestDelegate next
//RequestDelegate next IS THE SUBSEQUEST MIDDLEWARE
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello World");

    //HERE WE CALL NEXT MIDDLEWARE PASSING IN THE HTTP CONTEXT
    await next(context);

});

//INSTANTIATING (custom) MIDDLEWARE
//app.UseMiddleware<MyCustomMiddleware>();

//WE CAN USE EXTENSION METHODS TO SIMPLIFY THE ABOVE STATEMENT
//app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

//app.Use(async(HttpContext context, RequestDelegate next) =>
//{
//    context.Response.Headers["MyKey"] = "My value";
//    await next(context);
//});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello, I am the next middleware :D");
});
app.Run();
