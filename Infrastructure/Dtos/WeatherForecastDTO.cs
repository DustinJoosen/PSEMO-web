using Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Dtos
{
    /// <summary>
    ///     TEMPORARY!!! JUST FOR TESTING!!!
    /// </summary>
    public class WeatherForecastDTO
    {

        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}
