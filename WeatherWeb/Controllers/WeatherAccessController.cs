using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherWeb.Models;

namespace WeatherWeb.Controllers
{
    public class WeatherAccessController : Controller
    {
        public IActionResult Index()
        {
            // Fetch countries from your data source
            //var countries = GetCountriesFromDataSource();
            // Dummy list of countries
            var countries = new List<CountryModel>
        {
            new CountryModel { Name = "United States", Code = "us" },
            new CountryModel { Name = "United Kingdom", Code = "uk" },
            new CountryModel { Name = "Canada", Code = "ca" },
            // Add more dummy countries as needed
        };

                  


            var viewModel = new WeatherInfoViewModel
            {
                Countries = countries
                //ClientKey = randomClientKey
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(string country, string city)
        {
            List<string> clientKeys = new List<string>();
            clientKeys.Add("8b7535b42fe1c551f18028f64e8688f7");
            clientKeys.Add("9f933451cebf1fa39de168a29a4d9a79");
            clientKeys.Add("8b7535b42fe1c551f18028f64e8688f7");
            clientKeys.Add("9f933451cebf1fa39de168a29a4d9a79");
            clientKeys.Add("8b7535b42fe1c551f18028f64e8688f7");

            Random rand = new Random();
            // Generate a random index within the range of the list's count
            int randomIndex = rand.Next(clientKeys.Count);

            // Retrieve the random string value from the list using the generated index
            string clientKey = clientKeys[randomIndex];
            // Use HttpClient to call your API
            var client = new HttpClient();
            var apiUrl = "http://localhost:2030/Weather";
            // var response = await client.GetAsync($"{apiUrl}?country={country}&city={city}");
            var response = await client.GetAsync($"{apiUrl}/{city}/{country}/{clientKey}");

            if (response.IsSuccessStatusCode)
            {
                // Handle successful response
                var result = await response.Content.ReadAsStringAsync();                
                // Do something with the result
                return View("Weather", result);
            }
            else
            {
                // Handle unsuccessful response
                return Content("Error occurred while fetching data from the API.");
            }
        }
    }
}
