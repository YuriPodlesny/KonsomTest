namespace Konsom.Application.Models.Dto
{
    public class ReminderDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;

        public IList<TagDTO> Tag { get; set; } = new List<TagDTO>();
    }
}
