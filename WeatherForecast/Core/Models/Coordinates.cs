using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class Coordinates
    {
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }
    }
}
