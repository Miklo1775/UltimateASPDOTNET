using Microsoft.AspNetCore.Mvc;

namespace ViewsDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            //IF VIEW NAME IS NOT SPECIFIED, IT WILL USE THE ACTION NAME Index.cshtml
            //IT WILL SEARCH FOR THE VIEW AT Views/Home/Index.cshtml
            return View(); 
            //return new ViewResult() {ViewName = "abc"};
        }
    }
}
