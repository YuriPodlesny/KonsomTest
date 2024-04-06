using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder
{
    public class UpdateReminderCommandValidator : AbstractValidator<UpdateReminderCommand>
    {
        public UpdateReminderCommandValidator()
        {
            RuleFor(updateReminderCommandValidator => updateReminderCommandValidator.Id).NotEqual(Guid.Empty);
            RuleFor(updateReminderCommandValidator => updateReminderCommandValidator.Title).NotEmpty();
            RuleFor(updateReminderCommandValidator => updateReminderCommandValidator.Text).NotEmpty();
            RuleFor(updateReminderCommandValidator => updateReminderCommandValidator.Time).NotEqual(DateTime.MinValue);
        }
    }
}
