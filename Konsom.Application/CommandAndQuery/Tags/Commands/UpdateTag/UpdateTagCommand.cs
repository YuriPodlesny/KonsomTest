using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
