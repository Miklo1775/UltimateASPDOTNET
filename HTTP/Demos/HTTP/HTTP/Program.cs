using System.Collections;
using System.IO;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run( async (HttpContext context) =>
{
    //READING BODY FROM THE REQUEST OBJECT
    StreamReader reader = new(context.Request.Body);

    string body = await reader.ReadToEndAsync();

    //PARSING THE QUERY STRING INTO A DICTIONARY OBJECT
    //IF USING STRING, WE CAN ONLY USE ONE PROPERTY. IF USING STRINGVALUES, WE CAN USE MULTIPLE OF THE SAME PROPERTY
    Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
    foreach(KeyValuePair<string, StringValues> values in queryDict)
    {
        Console.WriteLine(values.Key);
        Console.WriteLine(values.Value);
    }

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
        
    }


    //context.Response.Headers["Content-Type"] = "text/html";
    //if(context.Request.Method == "GET")
    //{
    //    if(context.Request.Query.ContainsKey("id"))
    //    {
              //GETTING THE QUERY STRING
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<h2>{id}</h2>");
    //    }
    //}

    //CHECKING IF HEADERS CONTAIN A CERTAIN KEY
    //if (context.Request.Headers.ContainsKey("User-Agent"))
    //{
    //    string key = context.Request.Headers["User-Agent"];
    //    await context.Response.WriteAsync($"<h6> Key: {key}</h6>");
    // }

    //if (context.Request.Headers.ContainsKey("Authorization"))
    //{
    //    string authKey = context.Request.Headers["Authorization"];
    //    await context.Response.WriteAsync($"{authKey}");
    //}

    //GETTING PATH AND METHOD
    //string path = context.Request.Path;
    //string method = context.Request.Method;

    //SETTING RESPONSE HEADERS
    //context.Response.Headers["MyKey"] = "my value";
    //context.Response.Headers["Server"] = "Not Express.js";

    //SETIING RESPONSE STATUS CODE
    //context.Response.StatusCode = 200;

    //RETURNING RESPONSE
    //await context.Response.WriteAsync($"<h2>{path}</h2>");
    //await context.Response.WriteAsync($"<h2>{method}</h2>");
    //await context.Response.WriteAsync("<h1>This is true</h1>");
  
});

app.Run();