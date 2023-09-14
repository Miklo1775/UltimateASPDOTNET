using CountriesDemo.CustomConstraints;
using CountriesDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("invalidCountryID", typeof(CountryIDConstraintClass));
});

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/countries", async (HttpContext context) =>
    {
        Countries newSet = new();
        Dictionary<int, Country> countries = newSet.GetCountries();

        if(countries != null && countries.Count > 0)
        {
            context.Response.StatusCode = 200;
            foreach (KeyValuePair<int, Country> country in countries)
            {
                await context.Response.WriteAsync($"{country.Key}. {country.Value.CountryName}\n");
            }
        }
        
    });

    endpoints.MapGet("/countries/{countryID:int:range(1,100)}", async (HttpContext context) =>
    {   
        if (context.Request.RouteValues["countryID"] != null)
        {
            Countries newSet = new();
            Dictionary<int, Country> countries = newSet.GetCountries();

            int countryID = Convert.ToInt32(context.Request.RouteValues["countryID"]);

            if(!countries.ContainsKey(countryID))
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync($"[No Country]");
            }
            else
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"{countries[countryID].CountryName}");
            }
        }
    });

    endpoints.MapGet("/countries/{countryID:invalidCountryID}", async (HttpContext context) =>
    {
        if (context.Request.RouteValues["countryID"] != null)
        {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }
    });

});

app.Run();
