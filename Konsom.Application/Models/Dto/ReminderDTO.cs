namespace Konsom.Application.Models.Dto
{
    public class ReminderDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;
        public List<TagDTO> Tag { get; set; } = new List<TagDTO>();
    }
}
