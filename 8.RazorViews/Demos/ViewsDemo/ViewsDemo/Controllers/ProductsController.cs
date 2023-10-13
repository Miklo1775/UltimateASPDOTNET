using Microsoft.AspNetCore.Mvc;

namespace ViewsDemo.Controllers;

public class ProductsController : Controller
{
	// GET
	[Route("products/all")]
	public IActionResult All()
	{
		return View();
	}
}