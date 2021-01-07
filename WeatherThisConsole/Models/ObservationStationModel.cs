using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
    class ObservationStationModel
    {
        public List<ObservationStationFeatures> Features { get; set; }
    }

    class ObservationStationFeatures
    {
        public ObservationStationProperties Properties { get; set; }
    }

    class ObservationStationProperties
    {
        public string StationIdentifier { get; set; }
        public string Name { get; set; }
    }

}
