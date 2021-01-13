using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Views
{
    class SevenDayForecastView
    {
        public static async Task SevenDayForecast()
        {
            SevenDayForecastModel infoReturn;

            if (LocalValuesModel.IsImperial)
            {
                infoReturn = JsonConvert.DeserializeObject<SevenDayForecastModel>(LocalValuesModel.SevenDayForecastImperial);
            }
            else
            {
                infoReturn = JsonConvert.DeserializeObject<SevenDayForecastModel>(LocalValuesModel.SevenDayForecast);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" ╔═╗╔═╗╦  ╦╔═╗╔╗╔  ╔╦╗╔═╗╦ ╦  ╔═╗╔═╗╦═╗╔═╗╔═╗╔═╗╔═╗╔╦╗");
            Console.WriteLine(" ╚═╗║╣ ╚╗╔╝║╣ ║║║   ║║╠═╣╚╦╝  ╠╣ ║ ║╠╦╝║╣ ║  ╠═╣╚═╗ ║ ");
            Console.WriteLine(" ╚═╝╚═╝ ╚╝ ╚═╝╝╚╝  ═╩╝╩ ╩ ╩   ╚  ╚═╝╩╚═╚═╝╚═╝╩ ╩╚═╝ ╩");
            Console.WriteLine("");


            foreach (var period in infoReturn.Properties.Periods)
            {
                Console.Write("  ■  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{period.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(period.DetailedForecast);
            }

            await MenuView.ReturnToWelcome();
        }
    }
}
