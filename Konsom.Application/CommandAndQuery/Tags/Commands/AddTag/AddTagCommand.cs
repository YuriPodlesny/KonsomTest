using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.AddTag
{
    public class AddTagCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
    }
}
