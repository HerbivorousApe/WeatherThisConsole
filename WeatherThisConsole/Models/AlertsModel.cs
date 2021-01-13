using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherThisConsole.Models
{
    class AlertsModel
    {
        public List<AlertsFeatures> Features { get; set; }
    }

    class AlertsFeatures
    {
        public AlertsFeaturesProperties Properties { get; set; }
    }

    class AlertsFeaturesProperties
    {
        public static string Event { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
    }
}
