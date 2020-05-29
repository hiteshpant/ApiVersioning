using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioning.Controllers
{
    [ApiController]
    //2 way of specifying version in url , but this m3ans client has to change the url to consume new vewrsion of api
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] SummariesV1 = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = SummariesV1[rng.Next(SummariesV1.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetV3()
        {
            return new OkObjectResult("Response from versin 2");
        }
    }   
}
