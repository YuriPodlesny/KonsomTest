namespace Konsom.Domain
{
    public class Reminder : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;

        public List<ReminderTag> ReminderTags { get; set; } = new List<ReminderTag>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
