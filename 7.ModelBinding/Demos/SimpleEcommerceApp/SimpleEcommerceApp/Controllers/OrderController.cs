using Microsoft.AspNetCore.Mvc;

namespace SimpleEcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
