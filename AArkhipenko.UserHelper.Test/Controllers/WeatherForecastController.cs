using AArkhipenko.UserHelper.Providers;
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

    private readonly IUserProvider _userProvider;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IUserProvider userProvider,
        ILogger<WeatherForecastController> logger)
    {
        _userProvider = userProvider;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken = default)
    {
        var userModel = await _userProvider.GetUserAsync(cancellationToken);
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
