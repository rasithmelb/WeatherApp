using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WeatherApi.ActionFilters;
using WeatherApi.Helpers;
using WeatherApi.Interfaces;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IConfiguration _configuration;

        public WeatherController(IWeatherService weatherService, IConfiguration configuration)
        {
            _weatherService = weatherService;
            _configuration = configuration;
        }

        [RateLimit(limit: 5, periodInSeconds: 3600, clientKey: "78c3d8c6-efc8-495f-9250-3c5e64030d02")] // 5 requests per hr
        [HttpGet("{cityName}/{countryCode}/{clientKey}")]        
        public async Task<ActionResult<WeatherData>> Get(string cityName, string countryCode, string clientKey)
        {
            try
            {
                List<string> clientKeys = ConfigurationHelper.GetApiKeys(_configuration);
                if (clientKeys.Contains(clientKey))
                {
                    var api_key = ConfigurationHelper.GetRandomWeatherMapKeys(_configuration, 2);
                    var weatherData = await _weatherService.GetWeatherAsync(cityName, countryCode, api_key[0]);
                    return Ok(weatherData);
                }
                return null;
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "Failed to retrieve weather data.");
            }
        }
    }
}
