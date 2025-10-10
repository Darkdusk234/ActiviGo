using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs
{
    public class UpdateActivityOccurrenceDTO
    {
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [Required]
        public int SubLocationId { get; set; }

        public bool IsCancelled { get; set; }

        public int AvailableSpots { get; set; }
    }
}
