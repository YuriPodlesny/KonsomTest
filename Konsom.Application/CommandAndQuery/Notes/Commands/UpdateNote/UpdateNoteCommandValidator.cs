using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommandValidator => updateNoteCommandValidator.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommandValidator => updateNoteCommandValidator.Title).NotEmpty();
            RuleFor(updateNoteCommandValidator => updateNoteCommandValidator.Text).NotEmpty();
        }
    }
}
