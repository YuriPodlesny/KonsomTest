using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.DeleteTag
{
    public record DeleteTagCommand(Guid Id) : IRequest<Unit>;
}
