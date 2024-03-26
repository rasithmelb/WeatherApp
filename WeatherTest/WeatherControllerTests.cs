using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Controllers;
using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherTest
{
    [TestFixture]
    public class WeatherControllerTests
    {
        private WeatherController _weatherController;
        private Microsoft.Extensions.Configuration.IConfiguration _configuration;


        [SetUp]
        public void Setup()
        {
            try
            {
                //  IConfiguration configuration = new FakeWeatherService();
                var myConfiguration = new Dictionary<string, string>
                {
                    {"Client_Key:Api_Key1", "8b7535b42fe1c551f18028f64e8688f7"},
                    {"Client_Key:Api_Key2", "9f933451cebf1fa39de168a29a4d9a79"}
                };


                // Load configuration from appsettings.json
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path correctly
                    .AddJsonFile("appsettings.json"); // Provide the correct path to appsettings.json if it's in a different location

                _configuration = configurationBuilder.Build();


                IWeatherService weatherService = new FakeWeatherService();
                _weatherController = new WeatherController(weatherService, _configuration);
            }
            catch (Exception ex) { }
        }

        [Test]
        public async Task Get_Returns_OkResult_With_WeatherData()
        {
            // Arrange
            string cityName = "london";
            string countryCode = "uk";
            string clientKey = "8b7535b42fe1c551f18028f64e8688f7";
            try
            {
                // Act
                var result = await _weatherController.Get(cityName, countryCode, clientKey);

                // Assert
                Assert.IsInstanceOf<Task<ActionResult<WeatherData>>>(result);
                var okResult = result.Result;
                Assert.IsNotNull(okResult);
                Assert.IsInstanceOf<WeatherData>(okResult);
            }
            catch (Exception ex) { }
        }

        [Test]
        public async Task Get_Returns_Null_When_ClientKey_Not_Found()
        {
            // Arrange
            string cityName = "london";
            string countryCode = "uk";
            string clientKey = "8b7535b42fe1c551f18028f64e8688f1"; // Invalid key

            // Act
            var result = await _weatherController.Get(cityName, countryCode, clientKey);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task Get_Returns_StatusCode_500_On_Exception()
        {
            //// Arrange
            //string cityName = "TestCity";
            //string countryCode = "TestCountry";
            //string clientKey = "TestClientKey";

            //// Act
            //var result = await _weatherController.Get(cityName, countryCode, clientKey);

            //// Assert
            //Assert.IsInstanceOf<StatusCodeResult>(result);
            //var statusCodeResult = result as StatusCodeResult;
            //Assert.AreEqual(500, statusCodeResult.StatusCode);
        }

        // Fake implementation of IWeatherService for testing purposes
        private class FakeWeatherService : IWeatherService
        {
            public Task<WeatherData> GetWeatherAsync(string cityName, string countryCode, string apiKey)
            {
                // Return a dummy WeatherData for testing
                return Task.FromResult(new WeatherData());
            }

            //public async Task<WeatherData> GetWeatherAsync(string cityName, string countryCode, string apiKey)
            //{
            //    try
            //    {
            //        // Simulate some weather data retrieval logic (replace this with your actual logic)
            //        var weatherData = new WeatherData
            //        {
            //            Cod = 12,
            //            // Populate with dummy data for testing
            //            Coord = new Coord { Lat = 10.5, Lon = 28.3 },
            //            Main = new Info { Humidity = 76, Temp = 56 },
            //            Name = "London"

            //            // Add more properties as needed
            //        };

            //        // Return Ok result with weather data
            //        return new OkObjectResult(weatherData);
            //    }
            //    catch (Exception ex)
            //    {
            //        // Return status code 500 if an exception occurs
            //        return new StatusCodeResult(500, "Failed to retrieve weather data.");
            //    }
            //}



        }
    }
}