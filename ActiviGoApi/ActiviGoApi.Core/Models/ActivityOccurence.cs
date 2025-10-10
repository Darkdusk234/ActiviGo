using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Core.Models
{
    public class ActivityOccurence
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int Capacity { get; set; }
        //When creating a ActivitvyOccurence set availableSpots to Capacity
        public int AvailableSpots { get; set; }
        public bool IsCancelled { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        [Required]
        public int ActivityId { get; set; }
        [Required]
        public int SubLocationId { get; set; }

        // Navigation Properties
        public Activity? Activity { get; set; }
        public SubLocation? SubLocation { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
