using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWeb.Models
{
    public class WeatherInfoViewModel
    {
        public List<CountryModel> Countries { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

       // public string ClientKey { get; set; }
    }

    public class CountryModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
