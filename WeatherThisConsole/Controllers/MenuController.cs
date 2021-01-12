using System;
using System.Threading.Tasks;
using WeatherThisConsole.Views;

namespace WeatherThisConsole.Controllers
{
    class MenuController
    {
        public async Task Menu(ConsoleKey keyPress)
        {
            var view = new MainWelcomeView();
            var misc = new MiscController();
            var apiView = new APICallsView();
            var sevenDayForecast = new SevenDayForecastView();
            var sevenDayForecastHourly = new SevenDayForecastHourlyView();
            var sevenDayHistoryHourly = new SevenDayHistoryHourlyView();

            switch (keyPress)
            {
                case ConsoleKey.D1: await sevenDayForecast.SevenDayForecast(); break;
                case ConsoleKey.NumPad1: await sevenDayForecast.SevenDayForecast(); break;

                case ConsoleKey.D2: await sevenDayForecastHourly.SevenDayForecastHourly(); break;
                case ConsoleKey.NumPad2: await sevenDayForecastHourly.SevenDayForecastHourly(); break;


                case ConsoleKey.D3: await sevenDayHistoryHourly.SevenDayHistoryHourly(); break;
                case ConsoleKey.NumPad3: await sevenDayHistoryHourly.SevenDayHistoryHourly(); break;

                case ConsoleKey.D4: await apiView.UpdateZipView(); break;
                case ConsoleKey.NumPad4: await apiView.UpdateZipView(); break;

                case ConsoleKey.D5: misc.FlipIsImperial(); await view.Welcome(); break;
                case ConsoleKey.NumPad5: misc.FlipIsImperial(); await view.Welcome(); break;

                case ConsoleKey.Escape: Environment.Exit(0); break;

                default: Console.WriteLine(keyPress); break;
            }
        }
    }
}
