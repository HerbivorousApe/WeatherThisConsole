﻿using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Modeling everything for https://api.weather.gov/points/30.6712,-88.2321
/// </summary>
namespace WeatherThisConsole.Models
{
    class InfoReturnModel
    {
       // public List<string> Context { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
    }

    class Properties
    {
        public string Cwa { get; set; }
        public string ForecastOffice { get; set; }
        public string GridId { get; set; }
        public int GridX { get; set; }
        public int GridY { get; set; }
        public string Forecast { get; set; }
        public string ForecastHourly { get; set; }
        public string ForecastGridData { get; set; }
        public string ObservationStations { get; set; }
        public RelativeLocation RelativeLocation { get; set; }
        public string ForecastZone { get; set; }
        public string County { get; set; }
        public string FireWeatherZone { get; set; }
        public string TimeZone { get; set; }
        public string RadarStation { get; set; }
    }

    class Geometry
    {
        public string Type { get; set; }
        public double[] Coordinates { get; set; }
    }

    class RelativeLocation
    {
        public string Type { get; set; }
        public RelativeLocationGeometry Geometry { get; set; }
        public RelativeLocationProperties Properties { get; set; }

    }

    class RelativeLocationGeometry
    {
        public string Type { get; set; }
        public double[] Coordinates { get; set; }
    }

    class RelativeLocationProperties
    {
        public string City { get; set; }
        public string State { get; set; }
        public RelativeLocationPropertiesDistance Distance { get; set; }
        public RelativeLocationPropertiesBearing Bearing { get; set; }
    }

    class RelativeLocationPropertiesDistance
    {
        public double Value { get; set; }
        public string UnitCode { get; set; }

    }

    class RelativeLocationPropertiesBearing
    {
        public int Value { get; set; }
        public string UnitCode { get; set; }
    }
}