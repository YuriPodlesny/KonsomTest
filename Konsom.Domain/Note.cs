namespace Konsom.Domain
{
    public class Note : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;


        public List<NoteTag> NoteTags { get; } = new List<NoteTag>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
