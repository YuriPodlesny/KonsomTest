using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder
{
    public class DeleteReminderCommandValidator : AbstractValidator<DeleteReminderCommand>
    {
        public DeleteReminderCommandValidator()
        {
            RuleFor(deleteReminderCommand=>deleteReminderCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
