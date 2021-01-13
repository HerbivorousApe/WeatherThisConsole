using System;
using System.Threading.Tasks;
using WeatherThisConsole.Controllers;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Views
{
    class APICallsView
    {
        public static async Task GetGeoDataFromIP()
        {
            Console.WriteLine("");
            Console.WriteLine("Loading IP from icanhazip.com and geodata from ip-api.com ...");
            await APICallsController.GetGeoDataFromIP();
        }

        public static async Task GetLocationData()
        {
            Console.WriteLine("");
            Console.WriteLine("Loading location details from weather.gov ...");
            await APICallsController.GetWeatherLocationData();

            Console.WriteLine("");
            Console.WriteLine("Loading alert data from weather.gov ...");
            await APICallsController.GetAlertData();

            Console.WriteLine("");
            Console.WriteLine("Loading observation station identifier from weather.gov ...");
            await APICallsController.GetCurrentObservationStations();

            Console.WriteLine("");
            Console.WriteLine("Loading current and historical observation data from weather.gov ...");
            await APICallsController.GetCurrentObservationData();

            Console.WriteLine("");
            Console.WriteLine("Loading aggregate weather forecast data from weather.gov ...");
            await APICallsController.GetSevenDayForecast();

            Console.WriteLine("");
            Console.WriteLine("Loading granular forecast data from weather.gov ...");
            await APICallsController.GetSevenDayForecastHourly();

            await MainWelcomeView.Welcome();
        }

        public static async Task UpdateZipView()
        {
            Console.Write("Enter Zip: ");
            var newZip = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Loading latitude/longitude from zippopotam.us ...");

            try
            {
                await APICallsController.GetCoordsFromZip(newZip);
            }
            catch(Exception ex)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occured recovering zip code data.");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error: {ex}");
                Console.WriteLine("");
                await MenuView.ReturnToWelcome();
            }

            Console.WriteLine("");
            Console.WriteLine($"Location updated to {newZip} - {LocalValuesModel.City}, {LocalValuesModel.State}");

            await GetLocationData();
        }

    }
}
