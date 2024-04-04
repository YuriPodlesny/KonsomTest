using Konsom.Application.Models.Note;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes
{
    public record GetNotesQuery : IRequest<List<NoteDTO>>;
}
