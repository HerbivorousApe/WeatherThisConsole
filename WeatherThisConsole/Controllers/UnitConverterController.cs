using System;
using WeatherThisConsole.Models;

namespace WeatherThisConsole.Controllers
{
    class UnitConverterController
    {
        public decimal? ConvertCelsiusToFahrenheit(decimal? celsiusValue)
        {
            if (celsiusValue is null) return 0;
            var returnValue = (celsiusValue * Convert.ToDecimal(1.8)) + 32;
            if (!LocalValuesModel.IsImperial) returnValue = celsiusValue;
            return returnValue;
        }
        public decimal? ConvertKilometerToMile(decimal? kilometerValue)
        {
            if (kilometerValue is null) return 0;
            var returnValue = kilometerValue * Convert.ToDecimal(1.60934);
            if (!LocalValuesModel.IsImperial) returnValue = kilometerValue;
            return returnValue;
        }
        public string ConvertDegreeToDirection(decimal? degreeValue)
        {
            string returnValue = "-";

            if (degreeValue is null) return "-";

            if (degreeValue >= Convert.ToDecimal(348.75) && degreeValue < Convert.ToDecimal(11.25)) returnValue = "N";
            if (degreeValue >= Convert.ToDecimal(11.25) && degreeValue < Convert.ToDecimal(33.75)) returnValue = "NNE";
            if (degreeValue >= Convert.ToDecimal(33.75) && degreeValue < Convert.ToDecimal(56.25)) returnValue = "NE";
            if (degreeValue >= Convert.ToDecimal(56.25) && degreeValue < Convert.ToDecimal(78.75)) returnValue = "ENE";
            if (degreeValue >= Convert.ToDecimal(78.75) && degreeValue < Convert.ToDecimal(101.25)) returnValue = "E";
            if (degreeValue >= Convert.ToDecimal(101.25) && degreeValue < Convert.ToDecimal(123.75)) returnValue = "ESE";
            if (degreeValue >= Convert.ToDecimal(123.75) && degreeValue < Convert.ToDecimal(146.25)) returnValue = "SE";
            if (degreeValue >= Convert.ToDecimal(146.25) && degreeValue < Convert.ToDecimal(168.75)) returnValue = "SSE";
            if (degreeValue >= Convert.ToDecimal(168.75) && degreeValue < Convert.ToDecimal(191.25)) returnValue = "S";
            if (degreeValue >= Convert.ToDecimal(191.25) && degreeValue < Convert.ToDecimal(213.75)) returnValue = "SSW";
            if (degreeValue >= Convert.ToDecimal(213.75) && degreeValue < Convert.ToDecimal(236.25)) returnValue = "SW";
            if (degreeValue >= Convert.ToDecimal(236.25) && degreeValue < Convert.ToDecimal(258.75)) returnValue = "WSW";
            if (degreeValue >= Convert.ToDecimal(258.75) && degreeValue < Convert.ToDecimal(281.25)) returnValue = "W";
            if (degreeValue >= Convert.ToDecimal(281.25) && degreeValue < Convert.ToDecimal(303.75)) returnValue = "WNW";
            if (degreeValue >= Convert.ToDecimal(303.75) && degreeValue < Convert.ToDecimal(326.25)) returnValue = "NW";
            if (degreeValue >= Convert.ToDecimal(326.25) && degreeValue < Convert.ToDecimal(348.75)) returnValue = "NNW";

            return returnValue;
        }
    }
}
