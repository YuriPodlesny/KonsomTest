using Konsom.Application.Models.Reminder;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminders
{
    public record GetRemindersQuery : IRequest<List<ReminderDTO>>;
}
