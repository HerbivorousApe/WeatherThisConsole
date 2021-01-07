using System;
using System.Collections.Generic;
using System.Text;
using WeatherThisConsole.Models;
using WeatherThisConsole.Views;
using WeatherThisConsole.Controllers;

namespace WeatherThisConsole.Controllers
{
    public static class GlobalVariableController
    {
        public static string TestString { get; set; }
        //{
        //    Latitude = geoData.Lat,
        //    Longitude = geoData.Lon,
        //    IsImperial = true,
        //    RadarStation = weatherLocation.Properties.RadarStation,
        //    SevenDayForecastLink = weatherLocation.Properties.Forecast,
        //    City = geoData.City,
        //    State = geoData.RegionName
        //};
    }
}
