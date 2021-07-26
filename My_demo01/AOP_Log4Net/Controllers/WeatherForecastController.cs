using AOP_Log4Net.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AOP_Log4Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [LogFilter]
        [HttpPost]
        [Route("TestLog")]
        public string TestLog( string a ) 
        {
            _logger.LogInformation("hello");
            return a;
        }
    }
}
