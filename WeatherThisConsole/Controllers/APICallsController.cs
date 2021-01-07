using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherThisConsole.Models;
using WeatherThisConsole.Views;

namespace WeatherThisConsole.Controllers
{
    class APICallsController
    {
        public async Task GetLocationData()
        {
            Console.WriteLine("");
            Console.WriteLine("Loading location details from weather.gov ...");
            await GetWeatherLocationData();

            Console.WriteLine("");
            Console.WriteLine("Loading current and historical observation data from weather.gov ...");
            await GetCurrentObservationData();

            Console.WriteLine("");
            Console.WriteLine("Loading aggregate weather forecast data from weather.gov ...");
            await GetSevenDayForecast();

            Console.WriteLine("");
            Console.WriteLine("Loading granular forecast data from weather.gov ...");
            await GetSevenDayForecastHourly();

            var view = new InYourFaceInterface();
            await view.Welcome();
        }

        public async Task GetCoordsFromZip(string zip) // link = http://api.zippopotam.us/us/36695
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync($"http://api.zippopotam.us/us/{zip}");
            CoordsFromZipModel infoReturn = JsonConvert.DeserializeObject<CoordsFromZipModel>(response);

            LocalValuesModel.Latitude = Convert.ToDouble(infoReturn.Places[0].Latitude);
            LocalValuesModel.Longitude = Convert.ToDouble(infoReturn.Places[0].Longitude);
            LocalValuesModel.City = infoReturn.Places[0].PlaceName;
            LocalValuesModel.State = infoReturn.Places[0].State;
        }

        public async Task GetGeoDataFromIP() // link = http://ip-api.com/json/2600:1700:c910:1900::43?fields=regionName,city,district,zip,lat,lon
        {
            var client = new HttpClient();
            string externalIp = await client.GetStringAsync("http://icanhazip.com");
            externalIp = externalIp.Replace("\n", "");

            var response = await client.GetStringAsync($"http://ip-api.com/json/{externalIp}?fields=regionName,city,district,zip,lat,lon");

            GeoDataModel infoReturn = JsonConvert.DeserializeObject<GeoDataModel>(response);

            LocalValuesModel.Latitude = infoReturn.Lat;
            LocalValuesModel.Longitude = infoReturn.Lon;
            LocalValuesModel.City = infoReturn.City;
            LocalValuesModel.State = infoReturn.RegionName;
        }

        public async Task GetWeatherLocationData() // Link = https://api.weather.gov/points/34.0901,-118.4065
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");

            var response = await client.GetStringAsync($"https://api.weather.gov/points/{LocalValuesModel.Latitude},{LocalValuesModel.Longitude}");

            InfoReturnModel infoReturn = JsonConvert.DeserializeObject<InfoReturnModel>(response);

            LocalValuesModel.RadarStation = infoReturn.Properties.RadarStation;
            LocalValuesModel.SevenDayForecastLink = infoReturn.Properties.Forecast;
        }

        public async Task GetSevenDayForecast() // apiLink = https://api.weather.gov/gridpoints/MOB/44,64/forecast
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");

            var response = await client.GetStringAsync(LocalValuesModel.SevenDayForecastLink);

            LocalValuesModel.SevenDayForecast = response;
        }



        public async Task GetSevenDayForecastHourly() // link = https://api.weather.gov/gridpoints/MOB/44,64/forecast/hourly
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            
            var link = LocalValuesModel.SevenDayForecastLink + "/hourly";
            var response = await client.GetStringAsync(link);

            LocalValuesModel.SevenDayForecastHourly = response;
        }


        public async Task GetCurrentObservationData()  // link = https://api.weather.gov/stations/KMOB/observations
        {
            HttpClient client = new HttpClient();
            
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            var response = await client.GetStringAsync($"https://api.weather.gov/stations/{LocalValuesModel.RadarStation}/observations");

            LocalValuesModel.CurrentObservation = response;
        }
    }
}
