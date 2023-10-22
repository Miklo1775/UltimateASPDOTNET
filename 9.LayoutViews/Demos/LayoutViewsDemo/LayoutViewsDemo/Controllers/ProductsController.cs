using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsDemo.Controllers;

public class ProductsController : Controller
{
	// GET
	[Route("products")]
	public IActionResult Index()
	{
		ViewBag.Title = "All Products";
		return View();
	}
	
	[Route("search-products/{ProductID?}")]
	public IActionResult Search(int? ProductID)
	{
		ViewBag.ProductID = ProductID;
		ViewBag.Title = "Search for Products";
		return View();
	}

	[Route("order-product")]
	public IActionResult Order()
	{
		ViewBag.Title = "Order Product";
		return View();
	}
}