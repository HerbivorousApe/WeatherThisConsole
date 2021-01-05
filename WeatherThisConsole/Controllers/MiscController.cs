using System;
using System.Collections.Generic;
using System.Text;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Controllers
{
    class MiscController
    {
        public List<string> CreateDayList(SevenDayForecastHourlyModel sevenDayForecast)
        {
            var snip = sevenDayForecast.Properties.Periods;
            string snipDate = "";
            var returnValue = new List<string>();

            for (int i = 0; i < snip.Count; i++)
            {
                if (snipDate != snip[i].StartTime.ToString("MMM-dd"))
                {
                    snipDate = snip[i].StartTime.ToString("MMM-dd");
                    returnValue.Add(snipDate);
                }
            }
            return returnValue;
        }

        public List<string> CreateDayList(SevenDayHistoryHourlyModel sevenDayForecast)
        {
            var snip = sevenDayForecast.Properties.Periods;
            string snipDate = "";
            var returnValue = new List<string>();

            for (int i = 0; i < snip.Count; i++)
            {
                if (snipDate != snip[i].StartTime.ToString("MMM-dd"))
                {
                    snipDate = snip[i].StartTime.ToString("MMM-dd");
                    returnValue.Add(snipDate);
                }
            }
            return returnValue;
        }

        public List<string> CreateDayList(CurrentObservationModel sevenDayForecast)
        {
            var snip = sevenDayForecast.Features;
            string snipDate = "";
            var returnValue = new List<string>();

            for (int i = 0; i < snip.Count; i++)
            {
                if (snipDate != snip[i].Properties.Timestamp.ToString("MMM-dd"))
                {
                    snipDate = snip[i].Properties.Timestamp.ToString("MMM-dd");
                    returnValue.Add(snipDate);
                }
            }
            return returnValue;
        }

        public List<string> CreateTwentyFourHours()
        {
            var twentyFourHours = new List<string>()
            {
                "00:00", "01:00","02:00","03:00","04:00","05:00","06:00","07:00","08:00","09:00","10:00","11:00",
                "12:00","13:00","14:00","15:00","16:00","17:00","18:00","19:00","20:00","21:00","22:00","23:00",
            };

            return twentyFourHours;
        }
    }
}
