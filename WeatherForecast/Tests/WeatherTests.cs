using Newtonsoft.Json;
using NUnit.Framework;
using WeatherForecast.Core;
using WeatherForecast.Core.Models;

namespace WeatherForecast.Tests
{
    [TestFixture]
    public class WeatherTests
    {
        private WeatherData weatherData;
        
        [SetUp]
        public void Setup()
        {
            weatherData = JsonConvert.DeserializeObject<WeatherData>(WeatherJson.Data);
        }

        [Test]
        public void NoRainfallForDay1InLondon()
        {
            // Find the location for London
            var london = weatherData.Location.FirstOrDefault(loc => loc.City == "London");

            // Find the weather for day 1
            var day1Weather = london.Forecast.Weather.FirstOrDefault(weather => weather.Day == 1);

            // Assert that the precipitation (rainfall) for day 1 is 0
            Assert.AreEqual(0, day1Weather.Precipitation.Inches, "There should be no rainfall for day 1 in London.");
        }

        [Test]
        public void CorrectNumberOfEntriesForLondon()
        {
            // Find the expected entries for London
            var expectedEntries = weatherData.Location.FirstOrDefault(loc => loc.City == "London").Forecast.DayRange;

            // Find the actual entries count
            var actualEntries = weatherData.Location.FirstOrDefault(loc => loc.City == "London").Forecast.Weather.Count;

            // Assert entries are equal to day range
            Assert.AreEqual(expectedEntries, actualEntries, $"Number of entries for London should be {expectedEntries}");
        }

        [Test]
        public void PopulationUnknownForNewYork()
        {
            var newYorkPopulation = weatherData.Location.FirstOrDefault(loc => loc.City == "New York").Population;
            Assert.IsNull(newYorkPopulation, "New York population should be null");
        }

        [Test]
        public void PressureRoseInNewYorkFromDay1()
        {
            var newYorkWeather = weatherData.Location.FirstOrDefault(loc => loc.City == "New York").Forecast.Weather;
            var day1Pressure = newYorkWeather.FirstOrDefault(p => p.Day == 1).Pressure;
            var day2Pressure = newYorkWeather.FirstOrDefault(p => p.Day == 2).Pressure;
            Assert.Greater(day2Pressure, day1Pressure, "Day 2 pressure should be greater than day 1");
        }

        [Test]
        public void RainfallInLondonOnlyOverHalfInchTwice()
        {
            List<Weather> londonWeather = weatherData.Location.FirstOrDefault(loc => loc.City == "London").Forecast.Weather;

            int count = 0;
            foreach (Weather weather in londonWeather)
            {
                if (weather.Precipitation.Inches > 0.5)
                    count++;
            }
            Assert.AreEqual(2, count, "Rainfall was not over half an inch twice");
        }

        [Test]
        public void LondonOvercastForWholeDay5()
        {
            var day5CloudCover = weatherData.Location.FirstOrDefault(loc => loc.City == "London").Forecast.Weather.FirstOrDefault(day => day.Day == 5).CloudCover;

            Assert.That(day5CloudCover, Has.Some.Matches<CloudCover>(p => p.Description == "Overcast" && p.DayPosition == "All day"), "There is no overcast for all day in London");
        }

        [Test]
        public void TemperatureInNewYorkWithin10PercentOf24Celsius()
        {
            List<Weather> newYorkWeather = weatherData.Location.FirstOrDefault(loc => loc.City == "New York").Forecast.Weather;
            foreach (Weather weather in newYorkWeather)
            {
                var celsiusTemperature = weather.Temperature.Celsius;
                Assert.That(celsiusTemperature, Is.EqualTo(24.0).Within(24.0 * 0.1), "Temperature is not within 10% of 24 Celcius");
            }
        }
    }
 }