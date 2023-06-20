using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class Weather
    {
        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("precipitation")]
        public Precipitation Precipitation { get; set; }

        [JsonProperty("wind_speed")]
        public WindSpeed WindSpeed { get; set; }

        [JsonProperty("cloud_cover")]
        public List<CloudCover> CloudCover { get; set; }
    }
}
