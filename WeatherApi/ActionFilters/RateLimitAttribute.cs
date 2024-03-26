using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using WeatherApi.Helpers;

namespace WeatherApi.ActionFilters
{
    public class RateLimitAttribute : ActionFilterAttribute
    {
        private readonly int _limit;
        private readonly TimeSpan _period;
        private readonly Dictionary<string, (DateTime Timestamp, int Count)> _requestCounts;
        private readonly IConfiguration _configuration;
        private readonly string _clientApi;

        public RateLimitAttribute(int limit, int periodInSeconds,string clientKey)
        {
            _limit = limit;
            _period = TimeSpan.FromSeconds(periodInSeconds);
            _requestCounts = new Dictionary<string, (DateTime Timestamp, int Count)>();
            _clientApi = clientKey;
            
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var key = string.Empty;
            var api_key = _clientApi;
         
            // var key = $"{context.HttpContext.Request.Path}:{context.HttpContext.Connection.RemoteIpAddress}";
            if (api_key.Contains(_clientApi))
            {
                key = _clientApi;
              //  var key = "9450e574-19bf-490a-9984-4f19f30edcb7";
            }
            

            if (!_requestCounts.ContainsKey(key) || DateTime.Now - _requestCounts[key].Timestamp > _period)
            {
                _requestCounts[key] = (DateTime.Now, 1);
            }
            else
            {
                _requestCounts[key] = (_requestCounts[key].Timestamp, _requestCounts[key].Count + 1);
            }

            if (_requestCounts[key].Count > _limit)
            {
                context.Result = new StatusCodeResult(429); // Too Many Requests
                return;
            }

            await next();
        }
    }
}
