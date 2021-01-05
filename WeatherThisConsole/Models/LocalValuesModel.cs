using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
    class LocalValuesModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsImperial { get; set; }
        public string RadarStation { get; set; }
        public string SevenDayForecastLink { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
