using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.SubLocationDTOs
{
    public record UpdateSubLocationRequest
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public int MaxCapacity { get; init; }
        public bool Indoors { get; init; }
        public int LocationId { get; init; }

        DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    }
}
