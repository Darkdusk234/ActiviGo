namespace ActiviGoApi.Services.DTOs.BookingDTOs
{
    public class BookingReadDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int ActivityOccurenceId { get; set; }
        public DateTime BookingTime { get; set; }
        public bool ParticipationConfirmed { get; set; }
        public int Participants { get; set; }
        public bool IsActive { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCancelled { get; set; }

        //public string? UserName { get; set; }
        public string? ActivityName { get; set; }

        public DateTime ActivityStartTime { get; set; }
        public DateTime ActivityEndTime { get; set; }
    }
}
