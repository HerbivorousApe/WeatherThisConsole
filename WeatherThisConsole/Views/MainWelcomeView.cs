using System;
using WeatherThisConsole.Models;
using WeatherThisConsole.Controllers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherThisConsole.Views
{
    class MainWelcomeView
    {
        public static void Header()
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

        public static async Task Welcome()
        {
            Header();

            var unitType = (LocalValuesModel.IsImperial) ? "Imperial" : "Metric";

            Console.Write(" Current Location: "); 
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(LocalValuesModel.City); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(", "); 
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(LocalValuesModel.State); Console.ForegroundColor = ConsoleColor.Gray; 
            Console.Write("{0,-20}\t{1,-5}", "", $"System of Units: "); 
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(unitType); Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("");
            CurrentObservationData();
            Console.WriteLine("");
            SeventyTwoHourForecast();
            Console.WriteLine("");
            Alerts();

            await MenuView.Menu();
        }

        public static void CurrentObservationData()
        {
            var infoReturn = JsonConvert.DeserializeObject<CurrentObservationModel>(LocalValuesModel.CurrentObservation);

            var current = infoReturn.Features[0].Properties;

            var temp = Math.Round(Convert.ToDecimal(UnitConverterController.ConvertCelsiusToFahrenheit(current.Temperature.Value)));
            var dew = Math.Round(Convert.ToDecimal(UnitConverterController.ConvertCelsiusToFahrenheit(current.Dewpoint.Value)));
            var wind = Math.Round(Convert.ToDecimal(UnitConverterController.ConvertKilometerToMile(current.WindSpeed.Value)));
            var windDir = UnitConverterController.ConvertDegreeToDirection(current.WindDirection.Value);
            var humidity = Math.Round(Convert.ToDecimal(current.RelativeHumidity.Value));

            Console.Write("{0,-30}", " Current Conditions:");
            Console.Write("{0,-20}", $"TEMP: {temp}{LocalValuesModel.TempEnd}");
            Console.Write("{0,-20}", $"WND: {windDir} {wind}{LocalValuesModel.SpeedEnd}");
            Console.Write("{0,-20}", $"RH: {humidity}%");
            Console.WriteLine("{0,-20}", $"DWPT: {dew}{LocalValuesModel.TempEnd}");
        }

        public static void SeventyTwoHourForecast()
        {
            var infoReturn = JsonConvert.DeserializeObject<SevenDayForecastModel>(LocalValuesModel.SevenDayForecast);
            var period = infoReturn.Properties.Periods;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0,-20}", " " + period[0].Name);
            Console.Write("{0,-20}", period[1].Name);
            Console.Write("{0,-20}", period[2].Name);
            Console.Write("{0,-20}", period[3].Name);
            Console.Write("{0,-20}", period[4].Name);
            Console.WriteLine("{0,-20}", period[5].Name);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("{0,-20}", $"  {Math.Round((decimal)UnitConverterController.ConvertCelsiusToFahrenheit(period[0].Temperature), 0)}{LocalValuesModel.TempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)UnitConverterController.ConvertCelsiusToFahrenheit(period[1].Temperature), 0)}{LocalValuesModel.TempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)UnitConverterController.ConvertCelsiusToFahrenheit(period[2].Temperature), 0)}{LocalValuesModel.TempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)UnitConverterController.ConvertCelsiusToFahrenheit(period[3].Temperature), 0)}{LocalValuesModel.TempEnd}");
            Console.Write("{0,-20}", $"  {Math.Round((decimal)UnitConverterController.ConvertCelsiusToFahrenheit(period[4].Temperature), 0)}{LocalValuesModel.TempEnd}");
            Console.WriteLine("{0,-20}", $"  {Math.Round((decimal)UnitConverterController.ConvertCelsiusToFahrenheit(period[5].Temperature), 0)}{LocalValuesModel.TempEnd}");

            Console.Write("{0,-20}", $" WND: {period[0].WindDirection} " +
                $"{Math.Round((decimal)UnitConverterController.ConvertKilometerToMile(Convert.ToDecimal(period[0].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
            Console.Write("{0,-20}", $"WND: {period[1].WindDirection} " +
                $"{Math.Round((decimal)UnitConverterController.ConvertKilometerToMile(Convert.ToDecimal(period[1].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
            Console.Write("{0,-20}", $"WND: {period[2].WindDirection} " +
                $"{Math.Round((decimal)UnitConverterController.ConvertKilometerToMile(Convert.ToDecimal(period[2].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
            Console.Write("{0,-20}", $"WND: {period[3].WindDirection} " +
                $"{Math.Round((decimal)UnitConverterController.ConvertKilometerToMile(Convert.ToDecimal(period[3].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
            Console.Write("{0,-20}", $"WND: {period[4].WindDirection} " +
                $"{Math.Round((decimal)UnitConverterController.ConvertKilometerToMile(Convert.ToDecimal(period[4].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
            Console.WriteLine("{0,-20}", $"WND: {period[5].WindDirection} " +
                $"{Math.Round((decimal)UnitConverterController.ConvertKilometerToMile(Convert.ToDecimal(period[5].WindSpeed.Substring(0, 2).Trim())))}{LocalValuesModel.SpeedEnd}");
        }

        public static void Alerts()
        {
            var infoReturn = JsonConvert.DeserializeObject<AlertsModel>(LocalValuesModel.Alerts);

            foreach (var alert in infoReturn.Features)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"*** {alert.Properties.Headline} ***");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(alert.Properties.Description);
                Console.WriteLine(alert.Properties.Instruction);
            }
        }
    }
}
