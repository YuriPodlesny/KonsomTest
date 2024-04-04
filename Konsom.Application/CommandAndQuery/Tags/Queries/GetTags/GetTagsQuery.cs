using Konsom.Application.Models.Tag;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTags
{
    public record GetTagsQuery() : IRequest<List<TagDTO>>;
}
