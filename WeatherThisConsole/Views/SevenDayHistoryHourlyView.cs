using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeatherThisConsole.Controllers;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Views
{
    class SevenDayHistoryHourlyView
    {
        public async Task SevenDayHistoryHourly()
        {
            var infoReturn = JsonConvert.DeserializeObject<CurrentObservationModel>(LocalValuesModel.CurrentObservation);
            var unitConvert = new UnitConverterController();
            var menuView = new MenuView();

            var miscController = new MiscController();
            var snip = infoReturn.Features;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-12}", " TIME");

            var dayList = miscController.CreateDayListHistory();

            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0,-15}", $"  {dayList[i]}");
            }

            var hourArray = miscController.CreateTwentyFourHours();
            bool column;
            bool color = true;
            string lastHourDay = "";

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

                for (int i = 0; i < 7; i++)
                {
                    for (var j = 0; j < snip.Count; j++)
                    {
                        if (hour == snip[j].Properties.Timestamp.ToString("HH:00") && dayList[i] == snip[j].Properties.Timestamp.ToString("MMM-dd")
                            && lastHourDay != hour + dayList[i])
                        {
                            Console.Write("{0,-15}",
                                $"{Math.Round((decimal)unitConvert.ConvertCelsiusToFahrenheit(snip[j].Properties.Temperature.Value), 0)}{LocalValuesModel.TempEnd} / " +
                                $"{Math.Round((decimal)unitConvert.ConvertKilometerToMile(Convert.ToDecimal(snip[j].Properties.WindSpeed.Value)))}{LocalValuesModel.SpeedEnd}");

                            lastHourDay = hour + dayList[i];
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
