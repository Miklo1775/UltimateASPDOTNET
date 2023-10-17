using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsDemo.Controllers;

public class HomeController : Controller
{
	// GET
	[Route("/")]
	[Route("home")]
	public IActionResult Index()
	{
		ViewBag.Title = "Home";
		return View();
	}

	[Route("about-company")]
	public IActionResult About()
	{
		ViewBag.Title = "About Company";
		return View();
	}

	[Route("contact-support")]
	public IActionResult Contact()
	{
		ViewBag.Title = "Contact Support";
		return View();
	}
}