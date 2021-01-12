using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeatherThisConsole.Controllers;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Views
{
    class SevenDayForecastHourlyView
    {
        public async Task SevenDayForecastHourly()
        {
            var infoReturn = JsonConvert.DeserializeObject<SevenDayForecastHourlyModel>(LocalValuesModel.SevenDayForecastHourly);
            var unitConvert = new UnitConverterController();
            var menuView = new MenuView();

            var miscController = new MiscController();
            var snip = infoReturn.Properties.Periods;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-12}", " TIME");

            var dayList = miscController.CreateDayListForecast();

            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0,-15}", $"  {dayList[i]}");
            }

            var hourArray = miscController.CreateTwentyFourHours();
            bool column;
            bool color = true;

            foreach (string hour in hourArray)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (color) Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("");
                Console.Write("{0,-12}", $" {hour}");

                color = !color;
                if (color) Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.Gray;

                column = true;

                for (var i = 0; i < 7; i++)
                {
                    for (var j = 0; j < snip.Count; j++)
                    {
                        if (hour == snip[j].StartTime.ToString("HH:00") && dayList[i] == snip[j].StartTime.ToString("MMM-dd"))
                        {
                            Console.Write("{0,-15}",
                                $"{Math.Round((decimal)unitConvert.ConvertCelsiusToFahrenheit(snip[j].Temperature.Value), 0)}{LocalValuesModel.TempEnd} / " +
                                $"{Math.Round((decimal)unitConvert.ConvertKilometerToMile(Convert.ToDecimal(snip[j].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
                            column = false;
                        }
                    }

                    if (column)
                    {
                        Console.Write("{0,-15}", "");
                    }
                }

            }
            Console.WriteLine("");
            await menuView.ReturnToWelcome();
        }
    }
}
