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
        await context.Response.WriteAsync("In files");

        //GETTING THE ROUTE PARAMETERS
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

    //WE CAN SUPPLY DEFAULT VALUES FOR PARAMETERS INSIDE THE CURLY BRACES
    endpoints.Map("employee/profile/{employeename:length(3,8):alpha=Chichi}", async context =>
    {
        string? name = context.Request.RouteValues["employeename"]?.ToString();

        if (name != null)
        {
            await context.Response.WriteAsync($"{name}");
        }
    });

    //USING OPTIONAL PARAMETERS - {id?}
    //USING CONSTRAINT - {id:int?}
    //CONSTRAINTS ALLOW ONLY A CERTAIN TYPE TO BE ACCEPTED
    endpoints.Map("products/details/{id:int:range(1,100)?}", async (HttpContext context) =>
    {
        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);

        if(id != null)
        {
            await context.Response.WriteAsync($"{id}");
        }
        else
        {
            await context.Response.WriteAsync("Id is not supplied");
        }
    });

    //DATETIME CONSTRAINT EXAMPLE
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async (HttpContext context) => 
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);

        await context.Response.WriteAsync($"Report Date: {reportDate.ToShortDateString()}");
    });


    //GUIDE CONSTRAINT EXAMPLE
    endpoints.Map("cities/{cityid:guid}", async(HttpContext context) =>
    {
     Guid? cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);

        await context.Response.WriteAsync($"City information - {cityId}");
    });

    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"sales report - {year} = {month}");
    });


});

//THIS WILL ACT AS THE CATCH ALL ENDPOINT
app.Run( async (HttpContext context) => {
    await context.Response.WriteAsync("No routes matched\n");

    await context.Response.WriteAsync($"Request received at: {context.Request.Path}");
});


app.Run();
