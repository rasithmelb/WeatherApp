using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class WeatherData
    {
        // Define properties based on the API response structure
      

        [JsonProperty(PropertyName = "coord")]
        public Coord Coord { get; set; }

        [JsonProperty(PropertyName = "weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty(PropertyName = "@base")]
        public string @base { get; set; }

        [JsonProperty(PropertyName = "main")]
        public Info Main { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public int Visibility { get; set; }

        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }

        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty(PropertyName = "dt")]
        public int Dt { get; set; }

        [JsonProperty(PropertyName = "sys")]
        public Sys Sys { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public int Timezone { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "cod")]
        public int Cod { get; set; }
        }
        public class Clouds
        {
        [JsonProperty(PropertyName = "all")]
        public int All { get; set; }
        }

        public class Coord
        {
        [JsonProperty(PropertyName = "lon")]
        public double Lon { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Lat { get; set; }
        }

        public class Info
        {
        [JsonProperty(PropertyName = "temp")]
        public double Temp { get; set; }

        [JsonProperty(PropertyName = "feels_like")]
        public double Feels_like { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public double Temp_min { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public double Temp_max { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
        }



        public class Sys
        {
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty(PropertyName = "sunset")]
        public int Sunset { get; set; }
        }

        public class Weather
        {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        }

        public class Wind
        {
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        [JsonProperty(PropertyName = "deg")]
        public int Deg { get; set; }
        }

    
}
