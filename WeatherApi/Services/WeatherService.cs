using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string OpenWeatherMapBaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string cityName, string countryCode, string apiKey)
        {
            string url = $"{OpenWeatherMapBaseUrl}?q={cityName},{countryCode}&appid={apiKey}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            // using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseStream = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' }); 

                       
            //  return await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
           
            return JsonConvert.DeserializeObject<WeatherData>(responseStream);

        }
    }
}
