using System;
using System.Threading.Tasks;
using WeatherThisConsole.Controllers;

namespace WeatherThisConsole.Views
{
    class MenuView
    {

        public static async Task Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  1. Seven Day Forecast");
            Console.WriteLine("  2. Seven Day Forecast (Hourly)");
            Console.WriteLine("  3. Seven Day History (Hourly)");
            Console.WriteLine("  4. Change Location (Zip Code)");
            Console.WriteLine("  5. Toggle Metric/Imperial");
            Console.WriteLine("");
            Console.WriteLine("  Esc. to Exit");
            Console.ForegroundColor = ConsoleColor.Gray;

            ConsoleKey menuChoice = Console.ReadKey(true).Key;

            switch (menuChoice)
                {
                    case ConsoleKey.D1: await SevenDayForecastView.SevenDayForecast(); break;
                    case ConsoleKey.NumPad1: await SevenDayForecastView.SevenDayForecast(); break;

                    case ConsoleKey.D2: await SevenDayForecastHourlyView.SevenDayForecastHourly(); break;
                    case ConsoleKey.NumPad2: await SevenDayForecastHourlyView.SevenDayForecastHourly(); break;


                    case ConsoleKey.D3: await SevenDayHistoryHourlyView.SevenDayHistoryHourly(); break;
                    case ConsoleKey.NumPad3: await SevenDayHistoryHourlyView.SevenDayHistoryHourly(); break;

                    case ConsoleKey.D4: await APICallsView.UpdateZipView(); break;
                    case ConsoleKey.NumPad4: await APICallsView.UpdateZipView(); break;

                    
                    case ConsoleKey.D5: MiscController.FlipIsImperial(); await MainWelcomeView.Welcome(); break;
                    case ConsoleKey.NumPad5: MiscController.FlipIsImperial(); await MainWelcomeView.Welcome(); break;

                    case ConsoleKey.Escape: Environment.Exit(0); break;

                    default: await MainWelcomeView.Welcome(); break;
                }
            }

        public static async Task ReturnToWelcome()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to return to the menu or Esc to exit.");
            Console.ForegroundColor = ConsoleColor.Gray;

            ConsoleKey menuChoice = Console.ReadKey(true).Key;
            switch (menuChoice)
            {
                case ConsoleKey.Escape: Environment.Exit(0); break;
                default: await MainWelcomeView.Welcome(); break;
            }
        }
    }
}
