using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class Precipitation
    {
        [JsonProperty("mm")]
        public double Mm { get; set; }

        [JsonProperty("inches")]
        public double Inches { get; set; }
    }
}
