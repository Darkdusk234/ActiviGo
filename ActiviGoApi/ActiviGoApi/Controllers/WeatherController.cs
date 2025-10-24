using ActiviGoApi.Services.DTOs.WeatherDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpPost("LocationForecast")]
        public async Task<ActionResult<IEnumerable<WeatherResponseDTO>>> GetWeatherForecastByLocation([FromBody] WeatherLocationForecastRequestDTO dto, CancellationToken ct)
        {

            // Setting options for fetching
            var options = new RestClientOptions("https://opendata-download-metfcst.smhi.se/api/category/snow1g/version/1/geotype/point/")
            {
                ThrowOnAnyError = true,
                Timeout = TimeSpan.FromMilliseconds(3000)

            };
            // Example $"lon/{dto.Longitude}/lat/{dto.Latitude}/data.json?timeseries={timeseries}?parameters={parameters}";

            // The added url part to get correct data
            var url = $"lon/{dto.Longitude}/lat/{dto.Latitude}/data.json?parameters=air_temperature,probability_of_precipitation,symbol_code,wind_speed";

            // ????
            var client = new RestClient(options,
                        configureSerialization: s => s.UseSystemTextJson(new System.Text.Json.JsonSerializerOptions()));

            // forming the request
            var request = new RestRequest(url);



            try
            {
                // executing the request
                var response = await client.ExecuteGetAsync(request, ct);

                if(!response.IsSuccessful)
                {
                    return BadRequest($"Error in request: {response.Content.ToString()}");
                }
                // putting weatherdata into a jsonobject 
                var responseData = JsonSerializer.Deserialize<JsonObject>(response.Content);

                // creating array of all SMHI data
                var arr = responseData?["timeSeries"].AsArray();

                // creating an array of response dtos, to fill with... responses
                var dtoarr = new List<WeatherResponseDTO>();

                // loops trough all json nodes in json array
                foreach (var n in arr)
                {
                    // n contains date and time of forecast object
                    // extract into string for comparison
                    var dtstring = n?["intervalParametersStartTime"].GetValue<string>();

                    // this finds "sub-object" data in json node (n), contains weather info
                    var data = n?["data"];

                    // extract symbol code for testing
                    var scode = data?["symbol_code"].GetValue<string>();

                    // map all data into our response DTO
                    var weatherDto =
                         new WeatherResponseDTO
                         {
                             DateAndTime = n?["intervalParametersStartTime"].ToString(),
                             AirTemperature = data?["air_temperature"].ToString(),
                             WindSpeed = data?["wind_speed"].ToString(),
                             ProbabilityOfPrecipitation = data?["probability_of_precipitation"].ToString(),
                             SymbolCode = scode
                         };
                    if (weatherDto != null)
                    {
                        dtoarr.Add(weatherDto);
                    }

                }

                return Ok(dtoarr);
            }
            catch
            {
                return StatusCode(500, "Error fetching weather data");
            }

        }

        [HttpPost("weather-at-time")]
        //[ResponseCache(Duration = 10000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<ActionResult<WeatherResponseDTO>> GetWeatherByCoordinatesAndDateTime([FromBody] WeatherAtTimeRequestDTO dto, CancellationToken ct)
        {
            // Setting options for fetching
            var options = new RestClientOptions("https://opendata-download-metfcst.smhi.se/api/category/snow1g/version/1/geotype/point/")
            {
                ThrowOnAnyError = true,
                Timeout = TimeSpan.FromMilliseconds(3000)

            };
            // Example $"lon/{dto.Longitude}/lat/{dto.Latitude}/data.json?timeseries={timeseries}?parameters={parameters}";

            // The added url part to get correct data
            var url = $"lon/{dto.Longitude}/lat/{dto.Latitude}/data.json?parameters=air_temperature,probability_of_precipitation,symbol_code,wind_speed";

            // Creating RestCLient
            var client = new RestClient(options,
                        configureSerialization: s => s.UseSystemTextJson(new System.Text.Json.JsonSerializerOptions()));

            // forming the request
            var request = new RestRequest(url);



            try
            {
                // executing the request
                var response = await client.ExecuteGetAsync(request, ct);

                if (!response.IsSuccessful)
                {
                    return BadRequest($"Error in request: {response.Content.ToString()}");
                }
                // putting weatherdata into a jsonobject 
                var responseData = JsonSerializer.Deserialize<JsonObject>(response.Content);

                // creating array of all SMHI data
                var arr = responseData?["timeSeries"].AsArray();

                // Creating a dateTime-string from dto:

                string dt = dto.Date + "T" + dto.Time + "Z";

                // loops trough all json nodes in json array
                foreach (var n in arr)
                {
                    var data = n?["data"];


                    var dtstring = n?["intervalParametersStartTime"].GetValue<string>();



                    if (n?["intervalParametersStartTime"].ToString() == dt)
                    {

                        // if there is a direct match of date and time, return it:

                        var weatherDto =
                             new WeatherResponseDTO
                             {
                                 DateAndTime = n?["intervalParametersStartTime"].ToString(),
                                 AirTemperature = data?["air_temperature"].ToString(),
                                 WindSpeed = data?["wind_speed"].ToString(),
                                 ProbabilityOfPrecipitation = data?["probability_of_precipitation"].ToString(),
                                 SymbolCode = data?["symbol_code"].ToString().Remove(1)
                             };

                        return Ok(weatherDto);
                    }

                    // If requested time is not present in weather data, return weather at 12:00 of requested date

                    if (dtstring.Contains(dto.Date + "T" + "12:00:00Z"))
                    {
                        var weatherDto =
                             new WeatherResponseDTO
                             {
                                 DateAndTime = n?["intervalParametersStartTime"].ToString(),
                                 AirTemperature = data?["air_temperature"].ToString(),
                                 WindSpeed = data?["wind_speed"].ToString(),
                                 ProbabilityOfPrecipitation = data?["probability_of_precipitation"].ToString(),
                                 SymbolCode = data?["symbol_code"].ToString().Remove(1)
                             };

                        return Ok(weatherDto);

                    }

                    

                }

                return BadRequest("Weather of requested date could not be fetched");
                
            }
            catch
            {
                return StatusCode(500, "Error fetching weather data");
            }

            
        }
    }
}

