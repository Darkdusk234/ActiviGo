using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Services.DTOs
{
    public class BookingCreateDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ActivityOccurenceId { get; set; }

        [Required]
        [Range(1, 50)]
        public int Participants { get; set; }
    }
}
