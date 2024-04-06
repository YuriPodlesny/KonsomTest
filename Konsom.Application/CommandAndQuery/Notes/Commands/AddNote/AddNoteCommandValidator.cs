using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.AddNote
{
    public class AddNoteCommandValidator : AbstractValidator<AddNoteCommand>
    {
        public AddNoteCommandValidator()
        {
            RuleFor(addNoteComvand => addNoteComvand.Title).NotEmpty();
            RuleFor(addNoteComvand => addNoteComvand.Text).NotEmpty();
        }
    }
}
