using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs
{
    public record BookingCreateDTO
    {
        [Required]
        public int UserId { get; init; }

        [Required]
        public int ActivityOccurenceId { get; init; }

        [Required]
        [Range(1, 50)]
        public int Participants { get; init; }
    }
}
