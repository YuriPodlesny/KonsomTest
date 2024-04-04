using Konsom.Application.Models.Tag;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTag
{
    public record GetTagByIdQuery(Guid Id) : IRequest<TagDTO>;

}
