using Microsoft.AspNetCore.Mvc;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.Controllers;

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

	[Route("cats-list")]
	public IActionResult LoadCatsList()
	{
		PersonGridModel personsModel = new PersonGridModel()
		{
			GridTitle = "Hard Worker Cats",
			Persons = new List<Person>()
			{
				new Person()
				{
					JobTitle = "Destroyer of furniture",
					PersonName = "Chichi"
				},
				new Person()
				{
					JobTitle = "Food inventory specialist",
					PersonName = "Squishy"
				},
				new Person()
				{
					JobTitle = "Cat leader",
					PersonName = "Sylvestre"
				}
			}
		};
		return ViewComponent("Grid", new
		{
			grid = personsModel
		});
	}
}