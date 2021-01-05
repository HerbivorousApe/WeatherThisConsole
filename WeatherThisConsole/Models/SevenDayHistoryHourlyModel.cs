using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
        class SevenDayHistoryHourlyModel
        {
            public SevenDayForecastHourlyProperties Properties { get; set; }
        }

        class SevenDayHistoryHourlyProperties
    {
            public List<SevenDayForecastHourlyPeriods> Periods { get; set; }
        }

        class SevenDayHistoryHourlyPeriods
    {
            public DateTime StartTime { get; set; }
            public decimal? Temperature { get; set; }
            public string WindSpeed { get; set; }
            public string WindDirection { get; set; }
        }
    }

