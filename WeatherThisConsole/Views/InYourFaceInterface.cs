using System;
using System.Collections.Generic;
using System.Text;
using WeatherThisConsole.Models;
using WeatherThisConsole.Controllers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherThisConsole.Views
{
    class InYourFaceInterface
    {
        
        
        public void Header()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("██╗    ██╗███████╗ █████╗ ████████╗██╗  ██╗███████╗██████╗     ████████╗██╗  ██╗██╗███████╗");
            Console.WriteLine("██║    ██║██╔════╝██╔══██╗╚══██╔══╝██║  ██║██╔════╝██╔══██╗    ╚══██╔══╝██║  ██║██║██╔════╝");
            Console.WriteLine("██║ █╗ ██║█████╗  ███████║   ██║   ███████║█████╗  ██████╔╝       ██║   ███████║██║███████╗");
            Console.WriteLine("██║███╗██║██╔══╝  ██╔══██║   ██║   ██╔══██║██╔══╝  ██╔══██╗       ██║   ██╔══██║██║╚════██║");
            Console.WriteLine("╚███╔███╔╝███████╗██║  ██║   ██║   ██║  ██║███████╗██║  ██║       ██║   ██║  ██║██║███████║");
            Console.WriteLine(" ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝       ╚═╝   ╚═╝  ╚═╝╚═╝╚══════╝");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public async Task Welcome()
        {
            Header();

            var unitType = (LocalValuesModel.IsImperial) ? "Imperial" : "Metric";

            Console.Write(" Current Location: "); 
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(LocalValuesModel.City); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(", "); 
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(LocalValuesModel.State); Console.ForegroundColor = ConsoleColor.Gray; 
            Console.Write("{0,-20}\t{1,-5}", "", $"System of Units: "); 
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(unitType); Console.ForegroundColor = ConsoleColor.Gray;

            //Row for active alerts

            Console.WriteLine("");

            

            CurrentObservationData();
            Console.WriteLine("");
            SeventyTwoHourForecast();
            Console.WriteLine("");
            await Menu();

            //Console.Write($"If this is correct press Enter. Otherwise, please type your zip code then press Enter: ");
            //return Console.ReadLine();
        }


        public void CurrentObservationData()
        {
            CurrentObservationModel infoReturn = JsonConvert.DeserializeObject<CurrentObservationModel>(LocalValuesModel.CurrentObservation);
            UnitConverterController unitConvert = new UnitConverterController();

            var current = infoReturn.Features[0].Properties;

            var temp = Math.Round(Convert.ToDecimal(unitConvert.ConvertCelsiusToFahrenheit(current.Temperature.Value)));
            var dew = Math.Round(Convert.ToDecimal(unitConvert.ConvertCelsiusToFahrenheit(current.Dewpoint.Value)));
            var wind = Math.Round(Convert.ToDecimal(unitConvert.ConvertKilometerToMile(current.WindSpeed.Value)));
            var windDir = unitConvert.ConvertDegreeToDirection(current.WindDirection.Value);
            var humidity = Math.Round(Convert.ToDecimal(current.RelativeHumidity.Value));

            var tempEnd = "°F"; var speedEnd = "mph";

            if (!LocalValuesModel.IsImperial) { tempEnd = "°C"; speedEnd = "kph"; };

            Console.Write("{0,-30}", " Current Conditions:");
            Console.Write("{0,-20}", $"TEMP: {temp}{tempEnd}");
            Console.Write("{0,-20}", $"WND: {windDir} {wind}{speedEnd}");
            Console.Write("{0,-20}", $"RH: {humidity}%");
            Console.WriteLine("{0,-20}", $"DWPT: {dew}{tempEnd}");

        }

        public void SeventyTwoHourForecast()
        {

            SevenDayForecastModel infoReturn = JsonConvert.DeserializeObject<SevenDayForecastModel>(LocalValuesModel.SevenDayForecast);
            UnitConverterController unitConvert = new UnitConverterController();

            var period = infoReturn.Properties.Periods;

            var tempEnd = "°F"; var speedEnd = "mph";

            if (!LocalValuesModel.IsImperial) { tempEnd = "°C"; speedEnd = "kph"; };

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-20}", " " + period[0].Name);
            Console.Write("{0,-20}", period[1].Name);
            Console.Write("{0,-20}", period[2].Name);
            Console.Write("{0,-20}", period[3].Name);
            Console.Write("{0,-20}", period[4].Name);
            Console.WriteLine("{0,-20}", period[5].Name);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("{0,-20}", $"  {Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(period[0].Temperature), 0)}{tempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(period[1].Temperature), 0)}{tempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(period[2].Temperature), 0)}{tempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(period[3].Temperature), 0)}{tempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(period[4].Temperature), 0)}{tempEnd}");
            Console.WriteLine("{0,-20}", $"  {Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(period[5].Temperature), 0)}{tempEnd}");

            Console.Write("{0,-20}", $" WND: {period[0].WindDirection} " +
                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(period[0].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");
            Console.Write("{0,-20}", $"WND: {period[1].WindDirection} " +
                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(period[1].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");
            Console.Write("{0,-20}", $"WND: {period[2].WindDirection} " +
                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(period[2].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");
            Console.Write("{0,-20}", $"WND: {period[3].WindDirection} " +
                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(period[3].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");
            Console.Write("{0,-20}", $"WND: {period[4].WindDirection} " +
                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(period[4].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");
            Console.WriteLine("{0,-20}", $"WND: {period[5].WindDirection} " +
                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(period[5].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");

        }

        public async Task Menu()
        {
            MenuController menuController = new MenuController();

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

            //var controller = new MenuController();

            await menuController.Menu(menuChoice);
        }

        public async Task SevenDayForecastView()
        {
            SevenDayForecastModel infoReturn = JsonConvert.DeserializeObject<SevenDayForecastModel>(LocalValuesModel.SevenDayForecast);
            MenuController menuController = new MenuController();

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*** The seven day forecast is in Imperial units ***");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            
            foreach (var period in infoReturn.Properties.Periods)
            {
                Console.WriteLine($" ■ {period.Name} {period.DetailedForecast}");
            }

            await menuController.ReturnToWelcome();
        }

        public async Task SevenDayForecastHourlyView()
        {
            var infoReturn = JsonConvert.DeserializeObject<SevenDayForecastHourlyModel>(LocalValuesModel.SevenDayForecast);
            var unitConvert = new UnitConverterController();
            var menuController = new MenuController();

            var miscController = new MiscController();
            var snip = infoReturn.Properties.Periods;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-12}", " TIME");

            var dayList = miscController.CreateDayListForecast();

            //foreach (string day in dayList)
            //for (int i = 0; i < dayList.Count-1; i++)
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0,-15}", $"  {dayList[i]}");
            }

            var hourArray = miscController.CreateTwentyFourHours();
            bool column;
            bool color = true;

            var tempEnd = "°F"; var speedEnd = "mph";
            if (!LocalValuesModel.IsImperial) { tempEnd = "°C"; speedEnd = "kph"; };


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

                //for (var i = 0; i < dayList.Count-1; i++)
                for (var i = 0; i < 7; i++)
                    {
                    for (var j = 0; j < snip.Count; j++)
                    {
                        if (hour == snip[j].StartTime.ToString("HH:mm") && dayList[i] == snip[j].StartTime.ToString("MMM-dd"))
                        {
                            Console.Write("{0,-15}", 
                                $"{Math.Round((decimal)unitConvert.ConvertFahrenheitToCelsius(snip[j].Temperature.Value), 0)}{tempEnd} / " +
                                $"{Math.Round((decimal)unitConvert.ConvertMileToKilometer(Convert.ToDecimal(snip[j].WindSpeed.Substring(0, 2).Trim())))}{speedEnd}");
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
            await menuController.ReturnToWelcome(); 
        }

        public async Task SevenDayHistoryHourlyView()
        {
            var infoReturn = JsonConvert.DeserializeObject<CurrentObservationModel>(LocalValuesModel.CurrentObservation);
            var unitConvert = new UnitConverterController();
            var menuController = new MenuController();

            var miscController = new MiscController();
            var snip = infoReturn.Features;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-12}", " TIME");

            var dayList = miscController.CreateDayListHistory();

            //foreach (string day in dayList)
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0,-15}", $"  {dayList[i]}");
            }

            var hourArray = miscController.CreateTwentyFourHours();
            bool column;
            bool color = true;
            string lastHourDay = "";

            var tempEnd = "°F"; var speedEnd = "mph";
            if (!LocalValuesModel.IsImperial) { tempEnd = "°C"; speedEnd = "kph"; };


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

                //for (var i = 0; i < dayList.Count; i++)
                for (int i = 0; i < 7; i++)
                {
                    for (var j = 0; j < snip.Count; j++)
                    {
                        if (hour == snip[j].Properties.Timestamp.ToString("HH:00") && dayList[i] == snip[j].Properties.Timestamp.ToString("MMM-dd")
                            && lastHourDay != hour + dayList[i])
                        {
                            Console.Write("{0,-15}",
                                $"{Math.Round((decimal)unitConvert.ConvertCelsiusToFahrenheit(snip[j].Properties.Temperature.Value), 0)}{tempEnd} / " +
                                $"{Math.Round((decimal)unitConvert.ConvertKilometerToMile(Convert.ToDecimal(snip[j].Properties.WindSpeed.Value)))}{speedEnd}");

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
            await menuController.ReturnToWelcome();
        }

        public async Task UpdateZipView()
        {
            var apiController = new APICallsController();

            Console.Write("Enter Zip: ");
            var newZip = Console.ReadLine();

            await apiController.GetCoordsFromZip(newZip);

            Console.WriteLine("");
            Console.WriteLine($"Location updated to {newZip} - {LocalValuesModel.City}, {LocalValuesModel.State}");

            await apiController.GetLocationData();
        }
    }
}
