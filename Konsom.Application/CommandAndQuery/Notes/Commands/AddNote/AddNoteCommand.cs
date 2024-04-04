using Konsom.Application.Models.Note;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.AddNote
{
    public class AddNoteCommand : IRequest<NoteDTO>
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public Guid TagId { get; set; }
    }
}
