namespace Konsom.Domain
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public IList<Note> Notes { get; } = new List<Note>();
    }
}
