using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ActiviGoApi.Core.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public bool IsSuspended { get; set; } = false;

        // Navigation Properties
        public ICollection<Booking>? Bookings { get; set; }
    }
}
