using ApiService.Interfaces;
using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Services
{
    /// <summary>
    ///     TEMPORARY!!! JUST FOR TESTING!!!
    /// </summary>

    internal class WeatherForecastApiService : CrudAPIService<WeatherForecastDTO>, IWeatherForecastApiService
    {
        const string url = "/weather";

        public WeatherForecastApiService(HttpClient client) : base(client, url)
        {
        }
    }
}
