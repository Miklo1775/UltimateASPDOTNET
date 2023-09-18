using Microsoft.AspNetCore.Mvc;
using ModelValidationsDemo.Models;

namespace ModelValidationsDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            return Content($"{person}");
        }
    }
}
