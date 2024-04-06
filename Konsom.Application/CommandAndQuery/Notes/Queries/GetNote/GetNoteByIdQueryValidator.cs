using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNote
{
    public class GetNoteByIdQueryValidator : AbstractValidator<GetNoteByIdQuery>
    {
        public GetNoteByIdQueryValidator()
        {
            RuleFor(getNoteByIdQuery => getNoteByIdQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
