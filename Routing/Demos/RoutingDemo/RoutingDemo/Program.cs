using Microsoft.AspNetCore.Http;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//ENDPOINT OBJECT RETURNS NULL BEFORE USEROUTING() METHOD
//app.Use(async(context, next) =>
//{
//    Endpoint? endPoint = context.GetEndpoint();
//    if(endPoint != null)
//    {
//    await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");

//    }
//    await next(context);
//});

//ENABLING ROUTING USING app.UseRouting();
app.UseRouting();

//ENDPOINT MIDDLEWARE
//app.Use(async (context, next) =>
//{
//    //GETTING ENDPOINT OBJECT (NULLABLE) AND CHECKING IT IS NOT NULL. THEN RETRIEVING DISPLAYNAME PROP
//    Endpoint? endPoint = context.GetEndpoint();
//    if(endPoint != null)
//    {

//    await context.Response.WriteAsync($"Endpoint After: {endPoint.DisplayName}\n");
//    }
//    await next(context);
//});


//DEFINING ENDPOINTS WITH app.UseEndpoints();
app.UseEndpoints(endpoints => {
    //ADD ENPOINTS HERE
    //BY DEFAULT endpoints.Map() RUNS FOR ALL HTTP METHODS
    //endpoints.Map("map1", async (HttpContext context) => {
    //    await context.Response.WriteAsync("In Map 1");
    //});

    //endpoints.Map("map2", async (HttpContext context) =>
    //{
    //    await context.Response.WriteAsync("In Map 2");
    //});

    //endpoints.MapGet() AND .MapPost ARE MORE SPECIFIC 

    //endpoints.MapGet("Map", async (HttpContext context) =>
    //{
    //    await context.Response.WriteAsync("Are you getting it now, Mr. Krabs");
    //});

    //endpoints.MapPost("Map", async(HttpContext context) =>
    //{
    //    await context.Response.WriteAsync("Are you posting it now, Mr. Krabs");
    //}); 

    //USING ROUTING PARAMETERS
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        //GETTING THE ROUTE PARAMETERS
        await context.Response.WriteAsync("In files");

        string? fileName =context.Request.RouteValues["filename"]?.ToString();
        string? extension = context.Request.RouteValues["extension"]?.ToString();
        
        if(fileName != null)
        {
        await context.Response.WriteAsync($"Filename: {fileName}");

        }

        if(extension != null)
        {

        await context.Response.WriteAsync($"File-type: {extension}");
        }
        
    });

    endpoints.Map("employee/profile/{employeename}", async context =>
    {
        string? name = context.Request.RouteValues["employeename"]?.ToString();

        if (name != null)
        {
            await context.Response.WriteAsync($"{name}");
        }

    });

});




app.Run( async (HttpContext context) => {
    await context.Response.WriteAsync("Catch all middleware\n");

    await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});


app.Run();
