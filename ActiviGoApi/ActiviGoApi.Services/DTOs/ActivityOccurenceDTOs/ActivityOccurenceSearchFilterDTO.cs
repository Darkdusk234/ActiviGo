using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs
{
    public record ActivityOccurenceSearchFilterDTO
    {
        public string? NameFilter { get; init; }
        public int? SubLocationId { get; init; }
        public int? CategoryId { get; init; }
        public int? ActivityId { get; init; }
        public int? LocationId { get; init; }
        public bool? AvailableToBook { get; init; }

        // For geospatial filtering - not implemented
        //public string? NearLatitude { get; init; }
        //public string? NearLongitude { get; init; }
        //public int? WithinKilometers { get; init; }

        public DateTime? StartTime { get; init; }

        public DateTime? EndTime { get; init; }

        public int MaxPrice { get; init; } = 0;
    }
}
