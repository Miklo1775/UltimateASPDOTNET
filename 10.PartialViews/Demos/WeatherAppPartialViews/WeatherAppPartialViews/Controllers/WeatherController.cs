using Microsoft.AspNetCore.Mvc;
using WeatherAppPartialViews.Models;

namespace WeatherAppPartialViews.Controllers;

public class WeatherController : Controller
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
	[Route("weather")]
	public IActionResult Index()
	{
		ViewData["Title"] = "Weather";
		return View(_context);
	}

	[Route("single-city/{cityUniqueCode}")]
	public IActionResult SingleCity(string? cityUniqueCode)
	{
		if (cityUniqueCode == null)
		{
			ViewData["Title"] = "Error";
			return View("ErrorPage");
		}

		CityWeather? city = _context.FirstOrDefault(o => o.CityUniqueCode!
			.ToLower() == cityUniqueCode.ToLower());

		if (city == null)
		{
			ViewData["Title"] = "Error";
			return View("ErrorPage");
		}

		ViewData["Title"] = $"{city.CityName} Weather";
		return View(city);
	}
}