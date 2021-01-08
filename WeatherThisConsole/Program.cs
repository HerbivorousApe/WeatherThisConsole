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

            view.Header();

            Console.WriteLine("");
            Console.WriteLine("Loading IP from icanhazip.com and geodata from ip-api.com ...");
            await apiController.GetGeoDataFromIP();

            await apiController.GetLocationData();
        }
    }
}