using Microsoft.AspNetCore.Mvc;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.ViewComponents;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
	{
		// PersonGridModel model = new PersonGridModel()
		// {
		// 	GridTitle = "Persons",
		// 	Persons = new List<Person>()
		// 	{
		// 		new Person()
		// 			{ PersonName = "Chichi", JobTitle = "Drama Queen" },
		// 		new Person() { PersonName = "Cheddar", JobTitle = "Mama cat" },
		// 		new Person() { PersonName = "Zora", JobTitle = "Model cat" },
		// 		new Person() { PersonName = "Squishy", JobTitle = "Snow cat" }
		// 	}
		// };
		// ViewData["Grid"] = model;
		// return View("Sample"); //INVOKES A PARTIAL VIEW FROM Views/Shared/Components/Grid/Default.cshtml
		// BELOW WE ARE PASSING THE PERSONS TO THE VIEW AS AN OBJECT
		return View("Sample", grid);
	}
}