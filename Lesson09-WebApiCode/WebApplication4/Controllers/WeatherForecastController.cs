using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("test")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Counter _counter;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Counter counter)
        {
            _logger = logger;
            _counter = counter;
        }

        // test
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // test/CountName?name=test
        [HttpGet]
        [Route("CountName")]
        public int GetIt(string name)
        {
            _counter.AccessCounter += name.Length;
            return _counter.AccessCounter;
        }

        // test/nameit/dave
        [HttpGet]
        [Route("nameit/{name}")]
        public int GetName(string name)
        {
            return name.Length;
        }

        [HttpPost]
        public int MethodName(string name)
        {
            return name.Length;
        }



        [HttpGet]
        [Route("UpdateForecastObj")]
        public string UpdateForecastGet(Forecast forecast)
        {
            return $"The forecast you sent was {forecast.Weather} for {forecast.Day}";
        }

        [HttpGet]
        [Route("UpdateForecastParams")]
        public string UpdateForecastGet(string day, string weather)
        {
            return $"The forecast you sent was {weather} for {day}";
        }

        [HttpPost]
        [Route("Update")]
        public string UpdateForecast([FromBody] Forecast forecast)
        {
            return $"The forecast you sent was {forecast.Weather} for {forecast.Day}";
        }

        [HttpPost]
        [Route("UpdateDoesntWork")]
        public string DoesntWork(string day, string weather)
        {
            return $"The forecast you sent was {weather} for {day}";
        }
        [HttpPost]
        [Route("UpdateOtherDoesntWork")]
        public string DoesntWork1(Forecast forecast)
        {
            return $"The forecast you sent was {forecast.Weather} for {forecast.Day}";
        }


    }

    public class Forecast
    {

        public Forecast()
        {

        }

        public Forecast(DayOfWeek day, string weather)
        {
            Day = day.ToString();
            Weather = weather;
        }
        public string Day { get; set; }
        public string Weather { get; set; }
    }
}
