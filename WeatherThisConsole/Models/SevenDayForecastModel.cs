using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
    class SevenDayForecastModel
    {
        public SevenDayForeCastProperties Properties { get; set; }
    }

    class SevenDayForeCastProperties
    {
        public DateTime updated { get; set; }
        public List<SevenDayForecastPeriods> Periods { get; set; }
    }

    class SevenDayForecastPeriods
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsDayTime { get; set; }
        public int Temperature { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string ShortForecast { get; set; }
        public string DetailedForecast { get; set; }
    }
}
