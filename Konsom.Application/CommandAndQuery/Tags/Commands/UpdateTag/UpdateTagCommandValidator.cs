using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(updateTagCommand => updateTagCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateTagCommand => updateTagCommand.Name).NotEmpty();
        }
    }
}
