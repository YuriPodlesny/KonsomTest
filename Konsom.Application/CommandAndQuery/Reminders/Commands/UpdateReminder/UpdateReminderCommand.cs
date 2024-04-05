using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder
{
    public class UpdateReminderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;

        public IList<Tag> Tag { get; set; } = new List<Tag>();
    }
}
