using Microsoft.AspNetCore.Mvc;

namespace WeatherAppPartialViews.Controllers;

public class WeatherController : Controller
{
	[Route("/")]
	[Route("weather")]
	public IActionResult Index()
	{
		return View();
	}

	[Route("weather/single-city/{cityUniqueCode}")]
	public IActionResult SingleCity(string? cityUniqueCode)
	{
		return View();
	}
}