using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.ActivityDTOs
{
    public record UpdateActivityRequest
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        public int DurationInMinutes { get; init; }
        public string IMGUrl { get; init; } = string.Empty;
        public int MaxParticipants { get; init; }
        public bool IsActive { get; init; } 

        public int CategoryId { get; init; }

        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

    }
}
