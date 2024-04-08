using Konsom.Domain;

namespace Konsom.Application.Models.Dto
{
    public class NoteDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
