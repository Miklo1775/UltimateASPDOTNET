using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader reader = new(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);

    bool containsAllFields = queryDict.ContainsKey("firstNumber") && queryDict.ContainsKey("secondNumber") && queryDict.ContainsKey("operation");

    if (containsAllFields){

        int firstNumber;
        int secondNumber;
        int? operationValue;

        if (int.TryParse(queryDict["firstNumber"], out firstNumber) && int.TryParse(queryDict["secondNumber"], out secondNumber))
        {

            switch (queryDict["operation"])
            {
                case "addition": operationValue = firstNumber + secondNumber; break;
                case "multiplication": operationValue = firstNumber * secondNumber; break;
                case "subtraction": operationValue = firstNumber - secondNumber; break;
                case "division": operationValue = firstNumber / secondNumber; break;
                default: operationValue = null; break;
            }

            if(operationValue == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Ensure operation values are either addition, multiplication, subtraction, or division!");
            }
            else
            {
                context.Response.StatusCode=200;
                await context.Response.WriteAsync($"{operationValue}");
            }
        }

    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Needs required fields. Check your query and try again.");
    }
});

app.Run();
