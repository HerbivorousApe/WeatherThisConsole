using System;
using System.Threading.Tasks;
using WeatherThisConsole.Controllers;

namespace WeatherThisConsole.Views
{
    class MenuView
    {

        public async Task Menu()
        {
            var menuController = new MenuController();

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

            await menuController.Menu(menuChoice);
        }
        public async Task ReturnToWelcome()
        {
            var view = new MainWelcomeView();

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
