using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherThisConsole.Models;
using Geocoding.Google;
using System.Net;

namespace WeatherThisConsole
{
    class Program
    {
        HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetGeoLocation();
            await program.GetAPIData();

        }


        async Task GetGeoLocation()
        {
            var externalIp = new WebClient().DownloadString("http://icanhazip.com");
            var response = await client.GetStringAsync($"http://ip-api.com/json/{externalIp}?fields=lat,lon");
            InfoReturnModel infoReturn = JsonConvert.DeserializeObject<InfoReturnModel>(response);

        }

        async Task GetAPIData()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "SlackShack");
            var response = await client.GetStringAsync(
                "https://api.weather.gov/points/30.6712,-88.2321");

            //Console.WriteLine(response);

            InfoReturnModel infoReturn = JsonConvert.DeserializeObject<InfoReturnModel>(response);

            Console.WriteLine("{0,-60}\t{1,-5}", " Id:", infoReturn.Id);
            Console.WriteLine("{0,-60}\t{1,-5}", " Type:", infoReturn.Type);
            Console.WriteLine("{0,-60}\t{1,-5}", " Geometry>Type:", infoReturn.Geometry.Type);
            Console.WriteLine("{0,-60}\t{1,-5}", " Geometry>Coordinates[0] (long):", infoReturn.Geometry.Coordinates[0]);
            Console.WriteLine("{0,-60}\t{1,-5}", " Geometry>Coordinates[1] (lat):", infoReturn.Geometry.Coordinates[1]);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>Cwa:", infoReturn.Properties.Cwa);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>ForecastOffice:", infoReturn.Properties.ForecastOffice);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>GridId:", infoReturn.Properties.GridId);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>GridX:", infoReturn.Properties.GridX);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>GridY:", infoReturn.Properties.GridY);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>Forecast:", infoReturn.Properties.Forecast);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>ForecastHourly:", infoReturn.Properties.ForecastHourly);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>ForecastGridData:", infoReturn.Properties.ForecastGridData);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>ObservationStations:", infoReturn.Properties.ObservationStations);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Type:", infoReturn.Properties.RelativeLocation.Type);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Geometry>Type:", infoReturn.Properties.RelativeLocation.Geometry.Type);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Geometry>Coordinates[0](long):", infoReturn.Properties.RelativeLocation.Geometry.Coordinates[0]);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Geometry>Coordinates[1](lat):", infoReturn.Properties.RelativeLocation.Geometry.Coordinates[1]);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Properties>City:", infoReturn.Properties.RelativeLocation.Properties.City);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Properties>State:", infoReturn.Properties.RelativeLocation.Properties.State);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Properties>Distance>Value:", infoReturn.Properties.RelativeLocation.Properties.Distance.Value);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Properties>Distance>UnitCode:", infoReturn.Properties.RelativeLocation.Properties.Distance.UnitCode);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Properties>Bearing>Value:", infoReturn.Properties.RelativeLocation.Properties.Bearing.Value);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RelativeLocation>Properties>Bearing>UnitCode:", infoReturn.Properties.RelativeLocation.Properties.Bearing.UnitCode);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>ForecastZone:", infoReturn.Properties.ForecastZone);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>County:", infoReturn.Properties.County);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>FireWeatherZone:", infoReturn.Properties.FireWeatherZone);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>TimeZone:", infoReturn.Properties.TimeZone);
            Console.WriteLine("{0,-60}\t{1,-5}", " Properties>RadarStation:", infoReturn.Properties.RadarStation);
            Console.ReadLine();
        }
    }
}