using System.Reflection.PortableExecutable;
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
            // ViewData["people"] = persons;
            ViewBag.people = persons;
            ViewData["appTitle"] = "ASP.NET Core View Demo";
            
            //WHEN WE ARE USING A STRONGLY TYPED VIEW, WE SUPPLY THE DATA AS A PARAMETER IN THE View()
            //IF HAVE TO SUPPLY THE VIEW NAME, WE MUST SUPPLY THE VIEW NAME BEFORE THE OBJECT.
            return View("Index", persons); 
            //return new ViewResult() {ViewName = "abc"};
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name is null)
            {
                return Content("Person name cannot be null");
            }
            
            List<Person> persons = new List<Person>()
            {
                new Person(){Name = "Squishy", DateOfBirth = DateTime.Parse("2023-01-01"), PersonGender = Gender.Female},
                new Person() {Name = "Chichi", DateOfBirth = DateTime.Parse("2021-04-01"), PersonGender = Gender.Female},
                new Person(){Name = "Sylvestre", DateOfBirth = DateTime.Parse("2022-11-01"), PersonGender = Gender.Male},
                new Person() { Name = "Kinto", DateOfBirth = null, PersonGender = Gender.Male}
            };

            Person? matchedPerson = persons.Single(temp =>
                temp.Name?.ToLower() ==
                name.ToLower());
            
            return View("Details", matchedPerson);
        }
    }
}
