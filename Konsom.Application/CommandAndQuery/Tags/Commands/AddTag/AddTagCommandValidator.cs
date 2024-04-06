using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.AddTag
{
    public class AddTagCommandValidator : AbstractValidator<AddTagCommand>
    {
        public AddTagCommandValidator()
        {
            RuleFor(addTagCommand => addTagCommand.Name).NotEmpty();
        }
    }
}
