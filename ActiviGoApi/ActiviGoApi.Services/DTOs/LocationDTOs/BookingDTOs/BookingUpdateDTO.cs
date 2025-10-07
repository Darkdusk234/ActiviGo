using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs
{
    public class BookingUpdateDTO
    {
        [Required]
        [Range(1, 50)]
        public int Participants { get; set; }

        public bool ParticipationConfirmed { get; set; }
        public bool IsActive { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCancelled { get; set; }
    }
}
