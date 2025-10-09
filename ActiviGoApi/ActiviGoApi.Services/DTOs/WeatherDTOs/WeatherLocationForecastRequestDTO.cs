using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.WeatherDTOs
{
    public record WeatherLocationForecastRequestDTO
    {
        public string Latitude { get; init; } = string.Empty;
        public string Longitude { get; init; } = string.Empty;

    }
}
