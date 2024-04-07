namespace Konsom.Domain
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public List<Note> Notes { get; } = new List<Note>();
        public List<NoteTag> NoteTags { get; } = new List<NoteTag>();

        
        public List<Reminder> Reminders { get; } = new List<Reminder>();
        public List<ReminderTag> ReminderTags { get; } = new List<ReminderTag>();
    }
}
