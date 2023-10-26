using Microsoft.AspNetCore.Mvc;

namespace PartialViewsDemo.Controllers;

public class HomeController : Controller
{
	// GET
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult About()
	{
		return View();
	}
}