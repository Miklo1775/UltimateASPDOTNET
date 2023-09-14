using CountriesDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CountriesDemo.CustomMiddlware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CountriesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<int, Models.Country> _countries = new()
        {
            {1, new Country(1, "United States") },
            {2, new Country(2, "Canada") },
            {3, new Country(3, "United Kingdom")},
            {4, new Country(4, "India") },
            {5, new Country(5, "Japan") }

        };
        public CountriesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CountriesMiddlewareExtensions
    {
        public static IApplicationBuilder UseCountriesMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CountriesMiddleware>();
        }
    }
}
