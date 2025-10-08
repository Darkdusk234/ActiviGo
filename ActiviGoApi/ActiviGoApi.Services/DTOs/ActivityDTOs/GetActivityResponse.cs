using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.ActivityDTOs
{
    public record GetActivityResponse
    {
        public string ActivityId { get; set; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime Date { get; init; }
        public string Location { get; init; } = string.Empty;
        public int MaxParticipants { get; init; }
        public decimal Price { get; init; }

    }
}
