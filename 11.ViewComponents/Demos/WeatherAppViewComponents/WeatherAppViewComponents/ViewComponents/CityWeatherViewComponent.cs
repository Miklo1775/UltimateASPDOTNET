using Microsoft.AspNetCore.Mvc;
using WeatherAppViewComponents.Models;

namespace WeatherAppViewComponents.ViewComponents;

public class CityWeatherViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
	{
		return View("CityWeather", city);
	}
}