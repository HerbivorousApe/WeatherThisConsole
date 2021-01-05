using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
    class CurrentObservationModel
    {
        public List<COFeatures> Features { get; set; }
    }

    class COFeatures
    {
        public COFeaturesProperties Properties { get; set; }
    }

    class COFeaturesProperties
    {
        public DateTime Timestamp { get; set; }
        public string TextDescription { get; set; }
        public COFPTemperature Temperature { get; set; }
        public COFPDewpoint Dewpoint { get; set; }
        public COFPWindDirection WindDirection { get; set; }
        public COFPWindSpeed WindSpeed { get; set; }
        public COFPRelativeHumidity RelativeHumidity { get; set; }
    }

    class COFPTemperature { public decimal? Value { get; set; } }
    class COFPDewpoint { public decimal? Value { get; set; } }
    class COFPWindDirection { public decimal? Value { get; set; } }
    class COFPWindSpeed { public decimal? Value { get; set; } }
    class COFPRelativeHumidity { public decimal? Value { get; set; } }
}
