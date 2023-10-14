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
		return View( "City",_context);
	}

	[Route("single-city/{cityCode}")]
	public IActionResult SingleCity(string? cityCode)
	{
		if (cityCode == null)
		{
			return BadRequest("City Code cannot be null.");
		}

		List<CityWeather> city = new List<CityWeather>()
		{
			_context.Single(city =>
				city.CityUniqueCode!.ToLower() == cityCode
					.ToLower())
		};
	
	return View("City" ,city);
	}
}