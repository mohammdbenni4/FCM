using Microsoft.AspNetCore.Mvc;


namespace FCMTraining.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        string devicetoken = "ee9JVZaVRK-k9qwbnQ0Wv4:APA91bEll3PD0ta1spy8wjpXjzQft6XYTFZh3m_i8hKOGhMEV3bdrW1NJL6FSeX-V0QsWgiOV2fMEAoz75eMcajqOi_Q1mbsx6L8FQuy_tiRTJ64OgDGkaQsBlyqk_EuOl2MX045IacE";
        
        [HttpPost("send")]
        public async Task<IActionResult> Send()
        {
            var fcmService = new FcmService();
            await fcmService.SendNotificationToDeviceTokenAsync(devicetoken, "Hiiiiii", "Im Benni");

            return Ok();
        }

    }
}