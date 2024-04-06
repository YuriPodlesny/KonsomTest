using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder
{
    public class GetReminderByIdQueryValidator : AbstractValidator<GetReminderByIdQuery>
    {
        public GetReminderByIdQueryValidator()
        {
            RuleFor(getReminderByIdQuery => getReminderByIdQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
