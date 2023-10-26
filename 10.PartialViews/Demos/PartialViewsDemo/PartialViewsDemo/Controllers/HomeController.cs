using Microsoft.AspNetCore.Mvc;
using PartialViewsDemo.Models;

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

	[Route("programming-languages")]
	public IActionResult ProgrammingLanguages()
	{
		ListModel listModel = new ListModel()
		{
			ListTitle = "Programming Languages",
			ListItems = new List<string>()
			{
				"Java",
				"C#",
				"Python",
				"JavaScript"
			}
		};

		return PartialView("_ListPartialView", listModel);
	}
}