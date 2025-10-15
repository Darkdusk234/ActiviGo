using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Core.Models
{
    public class Booking
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public int ActivityOccurenceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool ParticipationConfirmed { get; set; } = false;
        [Required]
        [Range(1, 50)]
        public int Participants { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPaid { get; set; } = false;
        public bool IsCancelled { get; set; } = false;

        //Navigational Properties
        public ActivityOccurence? ActivityOccurence { get; set; }
        public User? User { get; set; }
    }
}
