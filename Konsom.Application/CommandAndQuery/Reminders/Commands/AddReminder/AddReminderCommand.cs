using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder
{
    public class AddReminderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
