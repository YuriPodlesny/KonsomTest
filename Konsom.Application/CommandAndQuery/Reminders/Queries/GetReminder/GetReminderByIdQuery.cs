using Konsom.Application.Models.Dto;   
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder
{
    public record GetReminderByIdQuery(Guid Id) : IRequest<ReminderDTO>;
}
