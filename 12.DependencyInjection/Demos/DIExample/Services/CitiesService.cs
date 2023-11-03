﻿using ServiceContracts;

namespace Services;

public class CitiesService : ICitiesService, IDisposable
{
	private List<string> _cities;

	private Guid _serviceInstanceId;

	public Guid ServiceInstanceId
	{
		get
		{
			return _serviceInstanceId;
		}
	}

	public CitiesService()
	{
		_serviceInstanceId = Guid.NewGuid();
		_cities = new List<string>()
		{
			"London",
			"Paris",
			"New York",
			"Tokyo",
			"Rome"
		};
		//TO DO: add logic to open db connection
	}

	public List<string> GetCities()
	{
		return _cities;
	}

	public void Dispose()
	{
		//TO DO: add logic to close db connection
	}
}