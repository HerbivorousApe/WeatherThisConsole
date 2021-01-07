using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
    public class SevenDayForecastModel
    {
        public SevenDayForecastProperties Properties { get; set; }
    }

    public class SevenDayForecastProperties
    {
        public DateTime Updated { get; set; }
        public List<SevenDayForecastPeriods> Periods { get; set; }
    }

    public class SevenDayForecastPeriods
    {
        public int Number { get; set; } = 0;
        public string Name { get; set; } = "";
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MaxValue;
        public bool IsDayTime { get; set; } = true;
        public int Temperature { get; set; } = 0;
        public string WindSpeed { get; set; } = "";
        public string WindDirection { get; set; } = "";
        public string ShortForecast { get; set; } = "";
        public string DetailedForecast { get; set; } = "";
    }
}
