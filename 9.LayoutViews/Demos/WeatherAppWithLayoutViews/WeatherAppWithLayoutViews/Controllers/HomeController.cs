using Microsoft.AspNetCore.Mvc;
using WeatherAppWithLayoutViews.Models;

namespace WeatherAppWithLayoutViews.Controllers;

public class HomeController : Controller
{
	private readonly List<CityWeather> _context = new List<CityWeather>()
	{
		new CityWeather()
		{
			CityUniqueCode = "LND", CityName = "London",
			DateAndTime = DateTime.Parse("2030-01-01"),
			TemperatureFahrenheit = 33
		},
		new CityWeather()
		{
			CityUniqueCode = "NYC", CityName = "New York City",
			DateAndTime = DateTime.Parse("2030-01-01"),
			TemperatureFahrenheit = 60
		},
		new CityWeather()
		{
			CityUniqueCode = "PAR", CityName = "Paris",
			DateAndTime = DateTime.Parse("2030-01-01"),
			TemperatureFahrenheit = 82
		}
	};
	
	[Route("/")]
	[Route("home")]
	public IActionResult Index()
	{
		ViewData["Title"] = "Weather";	
		return View(_context);
	}

	[Route("weather/{cityCode}")]
	public IActionResult SingleCity(string? cityCode)
	{
		
		if (cityCode == null)
		{
			return View("ErrorPage");
		}

		CityWeather? city = _context.FirstOrDefault(city => city.CityUniqueCode!.ToLower() == cityCode.ToLower());


		if (city == null)
		{
			return View("ErrorPage");
		}

		ViewData["Title"] = $"{city.CityName} Weather";
		
		return View(city);
	}
}