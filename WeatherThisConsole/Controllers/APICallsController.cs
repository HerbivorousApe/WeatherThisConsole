using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Controllers
{
    class APICallsController
    {

        public static async Task GetCoordsFromZip(string zip) // link = http://api.zippopotam.us/us/36695
        {
                var client = new HttpClient();
                var response = await client.GetStringAsync($"http://api.zippopotam.us/us/{zip}");
                CoordsFromZipModel infoReturn = JsonConvert.DeserializeObject<CoordsFromZipModel>(response);

                LocalValuesModel.Latitude = Convert.ToDouble(infoReturn.Places[0].Latitude);
                LocalValuesModel.Longitude = Convert.ToDouble(infoReturn.Places[0].Longitude);
                LocalValuesModel.City = infoReturn.Places[0].PlaceName;
                LocalValuesModel.State = infoReturn.Places[0].State;

        }

        public static async Task GetGeoDataFromIP() // link = http://ip-api.com/json/2600:1700:c910:1900::43?fields=regionName,city,district,zip,lat,lon
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

        public static async Task GetWeatherLocationData() // Link = https://api.weather.gov/points/34.0901,-118.4065
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");

            var response = await client.GetStringAsync($"https://api.weather.gov/points/{LocalValuesModel.Latitude},{LocalValuesModel.Longitude}");

            InfoReturnModel infoReturn = JsonConvert.DeserializeObject<InfoReturnModel>(response);

            LocalValuesModel.ObservationStationLink = infoReturn.Properties.ObservationStations;
            LocalValuesModel.RadarStation = infoReturn.Properties.RadarStation;
            LocalValuesModel.SevenDayForecastLink = infoReturn.Properties.Forecast;
            LocalValuesModel.ForecastZone = infoReturn.Properties.ForecastZone.Replace("https://api.weather.gov/zones/forecast/", "");
        }

        public static async Task GetAlertData() //https://api.weather.gov/alerts?active=true&status=actual
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            var link = $"https://api.weather.gov/alerts?active=true&status=actual&zone={LocalValuesModel.ForecastZone}";
            var response = await client.GetStringAsync(link);

            LocalValuesModel.Alerts = response;
        }

        public static async Task GetSevenDayForecast() // apiLink = https://api.weather.gov/gridpoints/MOB/44,64/forecast?units=si
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            var link = LocalValuesModel.SevenDayForecastLink + "?units=si";
            var response = await client.GetStringAsync(link);

            LocalValuesModel.SevenDayForecast = response;

            link = LocalValuesModel.SevenDayForecastLink;
            var responseImperial = await client.GetStringAsync(link);

            LocalValuesModel.SevenDayForecastImperial = responseImperial;
        }

        public static async Task GetSevenDayForecastHourly() // link = https://api.weather.gov/gridpoints/MOB/44,64/forecast/hourly?units=si
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            
            var link = LocalValuesModel.SevenDayForecastLink + "/hourly?units=si";
            var response = await client.GetStringAsync(link);

            LocalValuesModel.SevenDayForecastHourly = response;
        }

        public static async Task GetCurrentObservationData()  // link = https://api.weather.gov/stations/KMOB/observations
        {
            HttpClient client = new HttpClient();
            var link = $"https://api.weather.gov/stations/{LocalValuesModel.RadarStation}/observations";

            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            var response = await client.GetStringAsync(link);

            LocalValuesModel.CurrentObservation = response;
        }


        public static async Task GetCurrentObservationStations()  // link = https://api.weather.gov/gridpoints/MOB/44,65/stations
        {
            HttpClient client = new HttpClient();
            var link = LocalValuesModel.ObservationStationLink;

            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            var response = await client.GetStringAsync(link);

            ObservationStationModel infoReturn = JsonConvert.DeserializeObject<ObservationStationModel>(response);

            LocalValuesModel.RadarStation = infoReturn.Features[0].Properties.StationIdentifier;
            
        }
    }
}
