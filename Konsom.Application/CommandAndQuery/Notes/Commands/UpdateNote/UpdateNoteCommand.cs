using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public IList<Tag> Tag { get; set; } = new List<Tag>();
    }
}
