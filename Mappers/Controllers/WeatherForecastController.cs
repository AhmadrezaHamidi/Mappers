using AutoMapper;
using Mappers.AuthoDtos;
using Microsoft.AspNetCore.Mvc;

namespace Mappers.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMapper _mapper;
    public WeatherForecastController(ILogger<WeatherForecastController> logger,IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get()
    {
        var sourceModel = new SourceAuthoModel("Ahmad", 20);
        var destinationDTO = _mapper.Map<SourceAuthoModel, DestinationAuthoDTO>(sourceModel);
        var ttt = _mapper.Map<DestinationAuthoDTO>(sourceModel);
        return Ok(destinationDTO);
    }
}
