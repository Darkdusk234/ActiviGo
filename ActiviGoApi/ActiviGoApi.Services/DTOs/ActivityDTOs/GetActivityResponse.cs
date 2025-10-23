using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.ActivityDTOs
{
    public record GetActivityResponse
    {
        public int Id { get; set; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public int DurationInMinutes { get; init; }
        public string IMGUrl { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public bool IsActive { get; init; } 
        public int CategoryId { get; init; }
        public string CategoryName { get; init; } = string.Empty;

    }
}
