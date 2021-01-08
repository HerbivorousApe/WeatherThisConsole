
namespace WeatherThisConsole.Models
{
    public static class LocalValuesModel
    {
        public static double Latitude { get; set; }
        public static double Longitude { get; set; }
        public static bool IsImperial { get; set; } = true;
        public static string TempEnd { get; set; } = "°F";
        public static string SpeedEnd { get; set; } = "mph";
        public static string RadarStation { get; set; }
        public static string SevenDayForecastLink { get; set; }
        public static string ObservationStationLink { get; set; }
        public static string City { get; set; }
        public static string State { get; set; }
        
        public static string CurrentObservation { get; set; }
        public static string SevenDayForecast { get; set; }
        public static string SevenDayForecastImperial { get; set; }
        public static string SevenDayForecastHourly { get; set; }
        public static string ObservationStations { get; set; }
    }


}
