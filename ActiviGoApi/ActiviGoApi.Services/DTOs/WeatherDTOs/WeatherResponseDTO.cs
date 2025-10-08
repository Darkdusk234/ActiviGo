using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.WeatherDTOs
{
    public record WeatherResponseDTO
    {
        public string AirTemperature { get; init; } = string.Empty;
        public string WindSpeed { get; init; } = string.Empty;
        public string ProbabilityOfPrecipitation { get; init; } = string.Empty;
        public int SymbolCode { get; init; }
        public string DateAndTime { get; init; } = string.Empty;
    }
}
