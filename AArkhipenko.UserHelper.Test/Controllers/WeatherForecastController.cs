using AArkhipenko.UserHelper.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AArkhipenko.UserHelper.Test.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IUserHelper _userHelper;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IUserHelper userHelper,
        ILogger<WeatherForecastController> logger)
    {
        _userHelper = userHelper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken = default)
    {
        var userModel = await _userHelper.GetUserAsync(cancellationToken);
        _logger.LogInformation($"UserId = {userModel.Id}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
