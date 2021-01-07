using System;
using System.Collections.Generic;

namespace WeatherThisConsole.Models
{
    class SevenDayForecastHourlyModel
    {
        public SevenDayForecastHourlyProperties Properties { get; set; }
    }

    class SevenDayForecastHourlyProperties
    {
        public List<SevenDayForecastHourlyPeriods> Periods { get; set; }
    }

    class SevenDayForecastHourlyPeriods
    {
        public DateTime StartTime { get; set; }
        public decimal? Temperature { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
    }
}
