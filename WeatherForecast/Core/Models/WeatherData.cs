using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class WeatherData
    {
        [JsonProperty("location")]
        public List<Location> Location { get; set; }
    }
}
