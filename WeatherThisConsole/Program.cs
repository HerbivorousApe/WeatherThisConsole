using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherThisConsole.Models;
using WeatherThisConsole.Views;
using WeatherThisConsole.Controllers;
using System.Net;

namespace WeatherThisConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
                        
            var view = new InYourFaceInterface();
            var apiController = new APICallsController();

            Console.WriteLine("");
            Console.WriteLine("Loading GeoData from icanhazip.com ...");
            var geoData = await apiController.GetGeoDataFromIP();

            Console.WriteLine("");
            Console.WriteLine("Loading local weather data from weather.gov ...");
            var weatherLocation = await apiController.GetWeatherLocationData(geoData.Lat, geoData.Lon);

            var localValues = new LocalValuesModel()
            {
                Latitude = geoData.Lat,
                Longitude = geoData.Lon,
                IsImperial = true,
                RadarStation = weatherLocation.Properties.RadarStation,
                SevenDayForecastLink = weatherLocation.Properties.Forecast,
                City = geoData.City,
                State = geoData.RegionName
            };

            await view.Welcome(localValues);

        }
    }
}