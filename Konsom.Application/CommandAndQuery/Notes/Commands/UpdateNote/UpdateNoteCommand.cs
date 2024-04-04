using Konsom.Application.Models.Note;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<NoteDTO>
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public IList<Tag> Tag { get; set; } = new List<Tag>();
    }
}
