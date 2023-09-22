using Microsoft.AspNetCore.Mvc;
using SimpleEcommerceApp.Models;

namespace SimpleEcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind(nameof(Order.InvoicePrice), nameof(Order.Products), nameof(Order.OrderDate))] [FromForm] Order order)
        {
              if (!ModelState.IsValid)
                {
                    string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                    return BadRequest(errors);
                }

            return Json(order);
        }
    }
}
