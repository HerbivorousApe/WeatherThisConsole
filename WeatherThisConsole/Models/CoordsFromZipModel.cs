﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherThisConsole.Models
{
    class CoordsFromZipModel
    {
        public List<CoordsFromZipPlaces> Places { get; set; }
    }

    class CoordsFromZipPlaces
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [JsonProperty(PropertyName = "Place Name")] //City
        public string PlaceName { get; set; }
        public string State { get; set; }
    }


}
