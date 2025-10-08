using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.WeatherDTOs
{
    public record WeatherRequestDTO
    {
        //public string Adress { get; init; } = string.Empty; // Probably not necessary?
        public string? Latitude { get; init; } = string.Empty;
        public string? Longitude { get; init; } = string.Empty;

        public DateOnly Date { get; init; }
        public TimeOnly? Time { get; init; }
    }
}
