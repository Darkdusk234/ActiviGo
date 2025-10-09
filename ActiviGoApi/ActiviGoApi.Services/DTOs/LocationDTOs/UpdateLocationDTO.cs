using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.DTOs.LocationDTOs
{
    public class UpdateLocationDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
