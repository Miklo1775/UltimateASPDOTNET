using Microsoft.AspNetCore.Mvc;

namespace IActionResultDemo.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{bookId}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["bookId"]);
            return Content($"<h1>Book ID: {id}</h1>", "text/html");
        }
    }
}
