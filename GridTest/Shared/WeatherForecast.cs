using System;
using System.Collections.Generic;
using System.Text;

namespace GridTest.Shared
{
    public class WeatherForecast
    {
        public Guid key { get; set; } 
        public string Date { get; set; }

        public string TemperatureC { get; set; }

        public string Summary { get; set; }

        public string TemperatureF { get; set; }
    }
}
