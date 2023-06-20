using Newtonsoft.Json;

namespace WeatherForecast.Core.Models
{
    public class CloudCover
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cover_percentage")]
        public double? CoverPercentage { get; set; }

        [JsonProperty("day_position")]
        public string DayPosition { get; set; }
    }
}
