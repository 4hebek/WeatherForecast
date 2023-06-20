using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class Forecast
    {
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("day_range")]
        public int DayRange { get; set; }
    }
}
