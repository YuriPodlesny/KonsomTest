using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.AddNote
{
    public class AddNoteCommand : IRequest<Unit>
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public List<Guid>? TagId { get; set; }
    }
}
