using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("/LocationAndTime")]
        public async Task<ActionResult<WeatherResponseDTO>> GetWeatherByLocationAndTime([FromBody] WeatherRequestDTO request)
        {

        }
    }
}
