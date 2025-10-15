using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs.BookingDTOs
{
    public record BookingCreateDTO
    {
        [Required]
        public int ActivityOccurenceId { get; init; }

        [Required]
        [Range(1, 50)]
        public int Participants { get; init; }
    }
}
