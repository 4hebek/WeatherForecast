using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class Temperature
    {
        [JsonProperty("celsius")]
        public double Celsius { get; set; }

        [JsonProperty("fahrenheit")]
        public double Fahrenheit { get; set; }
    }
}
