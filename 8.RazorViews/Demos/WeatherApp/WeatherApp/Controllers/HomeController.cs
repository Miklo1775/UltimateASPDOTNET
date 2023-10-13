using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers;

public class HomeController : Controller
{
	private readonly List<CityWeather> _context = new List<CityWeather>()
	{
		new CityWeather()
		{
			CityUniqueCode = "LDN",
			CityName = "London",
			DateAndTime = DateTime.Parse("2030-01-01"),
			TemperatureFahrenheit = 33
		},
		new CityWeather()
		{
			CityUniqueCode = "NYC",
			CityName = "New York",
			DateAndTime = DateTime.Parse("2030-01-01"),
			TemperatureFahrenheit = 60
		},
		new CityWeather()
		{
			CityUniqueCode = "PAR",
			CityName = "Paris",
			DateAndTime = DateTime.Parse("2030-01-01"),
			TemperatureFahrenheit = 82
		}
	};
	
	// GET
	[Route("/")]
	public IActionResult AllCities()
	{
		return View(_context);
	}
}