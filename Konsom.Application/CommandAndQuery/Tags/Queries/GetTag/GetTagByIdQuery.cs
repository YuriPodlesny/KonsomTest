using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTag
{
    public record GetTagByIdQuery(Guid Id) : IRequest<TagDTO>;

}
