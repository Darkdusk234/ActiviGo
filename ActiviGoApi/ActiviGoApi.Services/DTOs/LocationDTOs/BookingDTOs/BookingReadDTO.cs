namespace ActiviGoApi.Services.DTOs
{
    public class BookingReadDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityOccurenceId { get; set; }
        public DateTime BookingTime { get; set; }
        public bool ParticipationConfirmed { get; set; }
        public int Participants { get; set; }
        public bool IsActive { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCancelled { get; set; }

        public string? UserName { get; set; }
        public string? ActivityName { get; set; }
    }
}
