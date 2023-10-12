using Microsoft.AspNetCore.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Person> persons = new List<Person>()
            {
                new Person(){Name = "Squishy", DateOfBirth = DateTime.Parse("2023-01-01"), PersonGender = Gender.Female},
                new Person() {Name = "Chichi", DateOfBirth = DateTime.Parse("2021-04-01"), PersonGender = Gender.Female},
                new Person(){Name = "Sylvestre", DateOfBirth = DateTime.Parse("2022-11-01"), PersonGender = Gender.Male},
                new Person() { Name = "Kinto", DateOfBirth = null, PersonGender = Gender.Male}
            };
            //IF VIEW NAME IS NOT SPECIFIED, IT WILL USE THE ACTION NAME Index.cshtml
            //IT WILL SEARCH FOR THE VIEW AT Views/Home/Index.cshtml
            ViewData["people"] = persons;
            ViewData["appTitle"] = "ASP.NET Core View Demo";
            return View(); 
            //return new ViewResult() {ViewName = "abc"};
        }
    }
}
