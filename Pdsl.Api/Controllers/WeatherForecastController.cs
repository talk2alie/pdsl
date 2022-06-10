using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Licensing;
using System.Security.Cryptography;

namespace Pdsl.Api.Controllers
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
        private readonly ITimedOneTimeAuthenticator _codeGenerator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITimedOneTimeAuthenticator codeGenerator)
        {
            _logger = logger;
            _codeGenerator = codeGenerator;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var code = _codeGenerator.GenerateCode();

            var user = new Visitor(new Name("Mo"), new Organization("UN"), new Email("talk2alie@outlook.com"), code.Secret);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}