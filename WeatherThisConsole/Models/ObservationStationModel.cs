using System.Collections.Generic;

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
