using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder
{
    public record DeleteReminderCommand(Guid Id) : IRequest<Unit>;
}
