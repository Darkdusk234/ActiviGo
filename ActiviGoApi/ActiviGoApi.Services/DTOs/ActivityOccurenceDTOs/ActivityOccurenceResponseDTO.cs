using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs
{
    public class ActivityOccurenceResponseDTO
    {
        public int Id { get; set; }
        public string ActivityName { get; set; } = string.Empty;
        public string SubLocationName { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string IMGUrl { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public int AvailableSpots { get; set; }
        public bool IsCancelled { get; set; }

        // Foreign Keys
        public int ActivityId { get; set; }
        public int SubLocationId { get; set; }
    }
}
