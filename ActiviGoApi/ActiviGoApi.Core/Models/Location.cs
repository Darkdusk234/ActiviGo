using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Core.Models
{
    public class Location
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        [Required]
        public string Latitude { get; set; } = string.Empty;
        [Required]
        public string Longitude { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public bool IsIndoors { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //Navigation Properties
        public ICollection<Activity>? Activities { get; set; }
        public ICollection<ActivityOccurence>? ActivityOccurrences { get; set; }
    }
}
