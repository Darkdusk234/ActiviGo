using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Core.Models
{
    public class Activity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int DurationInMinutes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public decimal Price { get; set; }
        public string IMGUrl { get; set; } = string.Empty;
        public bool IsIndoor { get; set; } = true;
        public bool IsActive { get; set; } = true;

        // Foreign Keys
        public int CategoryId { get; set; }

        // Navigation Properties
        public Category? Category { get; set; }
        public ICollection<ActivityOccurence>? ActivityOccurrences { get; set; }
        public ICollection<Location>? Locations { get; set; }
    }
}
