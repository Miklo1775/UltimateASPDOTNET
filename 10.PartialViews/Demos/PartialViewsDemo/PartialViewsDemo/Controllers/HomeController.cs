using Microsoft.AspNetCore.Mvc;

namespace PartialViewsDemo.Controllers;

public class HomeController : Controller
{
	[Route("/")]
	public IActionResult Index()
	{
		
		return View();
	}

	[Route("about")]
	public IActionResult About()
	{
		return View();
	}
}