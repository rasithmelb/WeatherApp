using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Helpers
{
    public static class ConfigurationHelper
    {
        public static List<string> GetRandomWeatherMapKeys(IConfiguration configuration, int count)
        {
            List<string> weatherMapKeys = new List<string>();

            // Get the Weather_Map section from appsettings.json
            var weatherMapSection = configuration.GetSection("Weather_Map");

            // Retrieve the keys and values from the Weather_Map section
            var keyValues = new Dictionary<string, string>();
            foreach (var child in weatherMapSection.GetChildren())
            {
                keyValues[child.Key] = child.Value;
            }

            // Get 'count' number of random keys
            var random = new Random();
            var keys = keyValues.Values;
            var availableKeys = new List<string>(keys);
            for (int i = 0; i < count; i++)
            {
                if (availableKeys.Count == 0)
                    break;

                int randomIndex = random.Next(0, availableKeys.Count);
                string randomKey = availableKeys[randomIndex];
                weatherMapKeys.Add(randomKey);
                availableKeys.RemoveAt(randomIndex);
            }

            return weatherMapKeys;
        }

        public static List<string> GetApiKeys(IConfiguration configuration)
        {
            List<string> apiKeys = new List<string>();

            // Get the Client_Key section from appsettings.json
            var clientKeySection = configuration.GetSection("Client_Key");

            // Iterate through each child element of Client_Key section and add its value to apiKeys list
            foreach (var child in clientKeySection.GetChildren())
            {
                // Add the value of each child to the apiKeys list
                apiKeys.Add(child.Value);
            }

            return apiKeys;
        }
    }
}
