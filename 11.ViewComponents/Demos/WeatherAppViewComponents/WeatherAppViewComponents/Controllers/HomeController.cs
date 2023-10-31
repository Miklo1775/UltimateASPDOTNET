using Microsoft.AspNetCore.Mvc;
using WeatherAppViewComponents.Models;

namespace WeatherAppViewComponents.Controllers;

public class HomeController : Controller
{
	private readonly List<CityWeather> _context = new List<CityWeather>()
	{
		new CityWeather()
		{
			CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse( 
                "2030-01-01 8:00"),  TemperatureFahrenheit = 33
		},
		new CityWeather()
		{
			CityUniqueCode = "NYC", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60
		},
		new CityWeather()
		{
			CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82
		}
	};
	public IActionResult Index()
	{
		return View();
	}
}