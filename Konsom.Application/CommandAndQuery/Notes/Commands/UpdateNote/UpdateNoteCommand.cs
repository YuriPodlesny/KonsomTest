using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }

        public List<Tag>? Tag { get; set; }
    }
}
