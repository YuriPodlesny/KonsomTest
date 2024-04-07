namespace Konsom.Domain
{
    public class ReminderTag
    {
        public Guid ReminderId { get; set; }
        public Guid TagId { get; set; }

        public Reminder Reminder { get; set; } = null!;
        public Tag Tag { get; set; } = null!;
    }
}
