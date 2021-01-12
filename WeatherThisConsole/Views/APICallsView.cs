using System;
using System.Threading.Tasks;
using WeatherThisConsole.Controllers;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Views
{
    class APICallsView
    {
        public async Task GetGeoDataFromIP()
        {
            var apiController = new APICallsController();

            Console.WriteLine("");
            Console.WriteLine("Loading IP from icanhazip.com and geodata from ip-api.com ...");
            await apiController.GetGeoDataFromIP();
        }

        public async Task GetLocationData()
        {
            var apiController = new APICallsController();

            Console.WriteLine("");
            Console.WriteLine("Loading location details from weather.gov ...");
            await apiController.GetWeatherLocationData();

            Console.WriteLine("");
            Console.WriteLine("Loading alert data from weather.gov ...");
            await apiController.GetAlertData();

            Console.WriteLine("");
            Console.WriteLine("Loading observation station identifier from weather.gov ...");
            await apiController.GetCurrentObservationStations();

            Console.WriteLine("");
            Console.WriteLine("Loading current and historical observation data from weather.gov ...");
            await apiController.GetCurrentObservationData();

            Console.WriteLine("");
            Console.WriteLine("Loading aggregate weather forecast data from weather.gov ...");
            await apiController.GetSevenDayForecast();

            Console.WriteLine("");
            Console.WriteLine("Loading granular forecast data from weather.gov ...");
            await apiController.GetSevenDayForecastHourly();

            var view = new MainWelcomeView();
            await view.Welcome();
        }

        public async Task UpdateZipView()
        {
            var apiController = new APICallsController();

            Console.Write("Enter Zip: ");
            var newZip = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Loading latitude/longitude from zippopotam.us ...");

            try
            {
                await apiController.GetCoordsFromZip(newZip);
            }
            catch(Exception ex)
            {
                var menuView = new MenuView();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occured recovering zip code data.");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error: {ex}");
                Console.WriteLine("");
                await menuView.ReturnToWelcome();
            }

            Console.WriteLine("");
            Console.WriteLine($"Location updated to {newZip} - {LocalValuesModel.City}, {LocalValuesModel.State}");

            await GetLocationData();
        }

    }
}
