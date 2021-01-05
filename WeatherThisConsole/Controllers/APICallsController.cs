using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherThisConsole.Models;
using WeatherThisConsole.Views;

namespace WeatherThisConsole.Controllers
{
    class APICallsController
    {
        

        public async Task<CoordsFromZipModel> GetCoordsFromZip(string zip)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"http://api.zippopotam.us/us/{zip}");
            CoordsFromZipModel infoReturn = JsonConvert.DeserializeObject<CoordsFromZipModel>(response);

            return infoReturn;
        }

        public async Task<GeoDataModel> GetGeoDataFromIP()
        {
            HttpClient client = new HttpClient();
            string externalIp = await client.GetStringAsync("http://icanhazip.com");
            externalIp = externalIp.Replace("\n", "");

            var response = await client.GetStringAsync($"http://ip-api.com/json/{externalIp}?fields=regionName,city,district,zip,lat,lon");
            GeoDataModel infoReturn = JsonConvert.DeserializeObject<GeoDataModel>(response);

            return infoReturn;

        }

        public async Task<InfoReturnModel> GetWeatherLocationData(double lat, double lon)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShackX");
            var response = await client.GetStringAsync($"https://api.weather.gov/points/{lat},{lon}");

            InfoReturnModel infoReturn = JsonConvert.DeserializeObject<InfoReturnModel>(response);

            return infoReturn;
        }

        public async Task<SevenDayForecastModel> GetSevenDayForecast(string apiLink) // apiLink = https://api.weather.gov/gridpoints/MOB/44,64/forecast
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShackX");
            var response = await client.GetStringAsync(apiLink);

            SevenDayForecastModel infoReturn = JsonConvert.DeserializeObject<SevenDayForecastModel>(response);

            return infoReturn;
        }

        public async Task<SevenDayForecastHourlyModel> GetSevenDayForecastHourly(string apiLink)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShackX");
            apiLink = apiLink + "/hourly";

            var response = await client.GetStringAsync(apiLink);

            SevenDayForecastHourlyModel infoReturn = JsonConvert.DeserializeObject<SevenDayForecastHourlyModel>(response);

            return infoReturn;
        }


        public async Task<CurrentObservationModel> GetCurrentObservationData(string radarStation)
        {
            HttpClient client = new HttpClient();
            //https://api.weather.gov/stations/KMOB/observations
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShackX");
            var response = await client.GetStringAsync($"https://api.weather.gov/stations/{radarStation}/observations");

            CurrentObservationModel infoReturn = JsonConvert.DeserializeObject<CurrentObservationModel>(response);

            return infoReturn;
        }
    }
}
