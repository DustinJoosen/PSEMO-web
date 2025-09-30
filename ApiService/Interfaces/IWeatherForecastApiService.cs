using Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    /// <summary>
    ///     TEMPORARY!!! JUST FOR TESTING!!!
    /// </summary>

    public interface IWeatherForecastApiService : ICrudAPIService<WeatherForecastDTO>
    {
    }
}
