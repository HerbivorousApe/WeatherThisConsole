using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherThisConsole.Models;
using WeatherThisConsole.Views;

namespace WeatherThisConsole.Controllers
{
    class MenuController
    {
        
        

        public async Task Menu(LocalValuesModel local, ConsoleKey keyPress)
        {
            APICallsController apiController = new APICallsController();
            InYourFaceInterface view = new InYourFaceInterface();

            var sevenDayForecast = await apiController.GetSevenDayForecast(local.SevenDayForecastLink);
            var sevenDayForecastHourly = await apiController.GetSevenDayForecastHourly(local.SevenDayForecastLink);
            var sevenDayHistoryHourly = await apiController.GetCurrentObservationData(local.RadarStation);

            switch (keyPress)
            {
                case ConsoleKey.D1: await view.SevenDayForecastView(sevenDayForecast, local); break;
                case ConsoleKey.NumPad1: await view.SevenDayForecastView(sevenDayForecast, local); break;

                case ConsoleKey.D2: await view.SevenDayForecastHourlyView(sevenDayForecastHourly, local); break;
                case ConsoleKey.NumPad2: await view.SevenDayForecastHourlyView(sevenDayForecastHourly, local); break;


                case ConsoleKey.D3: await view.SevenDayHistoryHourlyView(sevenDayHistoryHourly, local); break;
                case ConsoleKey.NumPad3: await view.SevenDayHistoryHourlyView(sevenDayHistoryHourly, local); break;

                case ConsoleKey.D4: await view.UpdateZipView(local); break;
                case ConsoleKey.NumPad4: await view.UpdateZipView(local); break;

                case ConsoleKey.D5: local.IsImperial = !local.IsImperial; await view.Welcome(local); break;
                case ConsoleKey.NumPad5: local.IsImperial = !local.IsImperial; await view.Welcome(local); break;

                case ConsoleKey.Escape: Environment.Exit(0); break;

                default: Console.WriteLine(keyPress); break;
            }
        }

        public async Task ReturnToWelcome(LocalValuesModel local)
        {
            InYourFaceInterface view = new InYourFaceInterface();

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to return to the menu or Esc to exit.");
            Console.ForegroundColor = ConsoleColor.Gray;

            ConsoleKey menuChoice = Console.ReadKey(true).Key;
            switch (menuChoice)
            {
                case ConsoleKey.Escape: Environment.Exit(0); break;
                default: await view.Welcome(local); break;
            }
        }
    }
}
