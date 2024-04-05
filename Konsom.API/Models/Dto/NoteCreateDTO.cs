using Konsom.Domain;

namespace Konsom.API.Models.Dto
{
    public class NoteCreateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public IList<Tag> Tag { get; set; } = new List<Tag>();
    }
}
