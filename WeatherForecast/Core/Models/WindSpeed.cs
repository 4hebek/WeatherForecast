using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class WindSpeed
    {
        [JsonProperty("mph")]
        public double Mph { get; set; }

        [JsonProperty("kph")]
        public double Kph { get; set; }
    }
}
