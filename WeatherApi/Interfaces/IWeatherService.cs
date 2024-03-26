using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Models;

namespace WeatherApi.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string cityName, string countryCode, string apiKey);
    }
}
