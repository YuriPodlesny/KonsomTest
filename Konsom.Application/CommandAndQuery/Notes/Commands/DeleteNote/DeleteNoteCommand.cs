using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote
{
    public record DeleteNoteCommand(Guid Id) : IRequest<Unit>;
}
