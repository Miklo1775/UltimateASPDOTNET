using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers;

public class HomeController : Controller
{
	private readonly ICitiesService _citiesService;

	public HomeController(ICitiesService citiesService)
	{
		//CREATING OBJECT OF CitiesService
		//HOWEVER, THIS IS VERY BAD PRACTICE BECAUSE NOW THE CONTROLLER IS DEPENDENT ON THE SERVICE
		// _citiesService = new CitiesService();
		_citiesService = citiesService;
	}
	
	[Route("/")]
	public IActionResult Index()
	{
		List<string> cities = _citiesService.GetCities();
		return View(cities);
	}
}