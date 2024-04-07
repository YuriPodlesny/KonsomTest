using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.AddNote
{
    public class AddNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; } = new Guid();
        public string? Title { get; set; }
        public string? Text { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
