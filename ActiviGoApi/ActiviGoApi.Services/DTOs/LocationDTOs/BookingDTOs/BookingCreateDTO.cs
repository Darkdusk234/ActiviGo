using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs
{
    public record BookingCreateDTO
    {
        [Required]
        public string UserId { get; init; } = string.Empty;

        [Required]
        public int ActivityOccurenceId { get; init; }

        [Required]
        [Range(1, 50)]
        public int Participants { get; init; }
    }
}
