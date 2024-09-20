using Microsoft.AspNetCore.Mvc;
using SOAP.Model;

namespace DotnetSoapStart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Service1Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Service1Controller> _logger;

        public Service1Controller(ILogger<Service1Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Produces("application/xml")]
        public IActionResult Post(SOAPRequestEnvelope env)
        {
            var res = new SOAPResponseEnvelope();
            res.Body.GetWeatherForecastResponse = new GetWeatherForecastResponse()
            {
                WeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                 .ToArray()
            };
            return Ok(res);

        }
    }
}
