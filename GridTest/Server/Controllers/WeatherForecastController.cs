using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GridTest.Shared;

namespace GridTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        private static List<WeatherForecast> wfl = new List<WeatherForecast>();

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            WeatherForecast a = new();
            a.key = Guid.NewGuid();
            a.TemperatureF = "1";
            a.TemperatureC = "2";
            a.Summary = "3";
            a.Date = "4";
            wfl.Add(a);
            return wfl;
        }

        [HttpPost]
        public ActionResult Post(WeatherForecast w)
        {
            w.key = Guid.NewGuid();
            wfl.Add(w);
            return Ok(w);
        }

        [HttpPut]
        public ActionResult Put(WeatherForecast w)
        {
            WeatherForecast myr = (from x in wfl where x.key == w.key select x).FirstOrDefault<WeatherForecast>();
            wfl.Remove(myr);
            wfl.Add(w);

            return Ok(w);
        }

        [HttpDelete]
        public ActionResult Delete(Guid key)
        {
            WeatherForecast myr = (from x in wfl where x.key == key select x).FirstOrDefault<WeatherForecast>();
            wfl.Remove(myr);

            return Ok();
        }
    }
}
