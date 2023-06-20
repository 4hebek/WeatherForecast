using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class Location
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("population")]
        public long? Population { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }       
    }
}
