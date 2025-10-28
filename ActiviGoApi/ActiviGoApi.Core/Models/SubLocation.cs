using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Core.Models
{
    public class SubLocation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int MaxCapacity { get; set; }

        public bool Indoors { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int LocationId { get; set; } // Foreign Key

        // Navigation Properties
        public Location? Location { get; set; }
        public ICollection<ActivityOccurence>? ActivityOccurences { get; set; } 
        public ICollection<Activity>? Activities { get; set; } 

    }
}
