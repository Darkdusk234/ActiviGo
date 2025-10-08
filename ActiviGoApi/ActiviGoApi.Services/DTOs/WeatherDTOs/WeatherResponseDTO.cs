using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.WeatherDTOs
{
    public record WeatherResponseDTO
    {
        public string WeatherDescription { get; init; } = string.Empty;
        public float TemperatureCelsius { get; init; }
        public string WeatherImgUrl { get; init; } = string.Empty;
        public DateTime ObservationTime { get; init; }
    }
}
