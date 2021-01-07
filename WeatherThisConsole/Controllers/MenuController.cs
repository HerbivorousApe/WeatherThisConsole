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
        
        public async Task Menu(ConsoleKey keyPress)
        {

            var view = new InYourFaceInterface();

            switch (keyPress)
            {
                case ConsoleKey.D1: await view.SevenDayForecastView(); break;
                case ConsoleKey.NumPad1: await view.SevenDayForecastView(); break;

                case ConsoleKey.D2: await view.SevenDayForecastHourlyView(); break;
                case ConsoleKey.NumPad2: await view.SevenDayForecastHourlyView(); break;


                case ConsoleKey.D3: await view.SevenDayHistoryHourlyView(); break;
                case ConsoleKey.NumPad3: await view.SevenDayHistoryHourlyView(); break;

                case ConsoleKey.D4: await view.UpdateZipView(); break;
                case ConsoleKey.NumPad4: await view.UpdateZipView(); break;

                case ConsoleKey.D5: LocalValuesModel.IsImperial = !LocalValuesModel.IsImperial; await view.Welcome(); break;
                case ConsoleKey.NumPad5: LocalValuesModel.IsImperial = !LocalValuesModel.IsImperial; await view.Welcome(); break;

                case ConsoleKey.Escape: Environment.Exit(0); break;

                default: Console.WriteLine(keyPress); break;
            }
        }

        public async Task ReturnToWelcome()
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
                default: await view.Welcome(); break;
            }
        }
    }
}
