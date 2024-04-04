using Konsom.Application.Models.Note;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNote
{
    public record GetNoteByIdQuery(Guid Id) : IRequest<NoteDTO>;

}
