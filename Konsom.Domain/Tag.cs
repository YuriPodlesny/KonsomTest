namespace Konsom.Domain
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public IList<Note> Notes { get; } = new List<Note>();
        public IList<Reminder> Peminders { get; } = new List<Reminder>();
    }
}
