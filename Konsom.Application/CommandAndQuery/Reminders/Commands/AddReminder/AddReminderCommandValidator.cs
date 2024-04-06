using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder
{
    public class AddReminderCommandValidator : AbstractValidator<AddReminderCommand>
    {
        public AddReminderCommandValidator()
        {
            RuleFor(addReminderCommand=>addReminderCommand.Title).NotEmpty();
            RuleFor(addReminderCommand => addReminderCommand.Text).NotEmpty();
            RuleFor(addReminderCommand => addReminderCommand.Time).NotEqual(DateTime.MinValue);
        }
    }
}
