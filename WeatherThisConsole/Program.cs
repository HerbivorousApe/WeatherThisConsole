using System;
using System.Threading.Tasks;
using WeatherThisConsole.Models;
using WeatherThisConsole.Views;
using WeatherThisConsole.Controllers;


namespace WeatherThisConsole
{
    class Program
    {
        static async Task Main()
        {    
            var view = new InYourFaceInterface();
            var apiController = new APICallsController();

            LocalValuesModel.IsImperial = true;

            view.Header();

            Console.WriteLine("");
            Console.WriteLine("Loading geodata from icanhazip.com ...");
            await apiController.GetGeoDataFromIP();

            await apiController.GetLocationData();
        }
    }
}