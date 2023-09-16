using Microsoft.AspNetCore.Mvc;

namespace IActionResultDemo.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public IActionResult Books()
        {
            return StatusCode(200);
        }
    }
}
