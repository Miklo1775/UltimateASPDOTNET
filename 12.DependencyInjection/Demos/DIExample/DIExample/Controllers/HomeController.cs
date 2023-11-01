using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers;

public class HomeController : Controller
{
	private readonly CitiesService _citiesService;

	public HomeController()
	{
		//CREATING OBJECT OF CitiesService
		//HOWEVER, THIS IS VERY BAD PRACTICE BECAUSE NOW THE CONTROLLER IS DEPENDENT ON THE SERVICE
		_citiesService = new CitiesService();
	}
	
	[Route("/")]
	public IActionResult Index()
	{
		List<string> cities = _citiesService.GetCities();
		return View(cities);
	}
}