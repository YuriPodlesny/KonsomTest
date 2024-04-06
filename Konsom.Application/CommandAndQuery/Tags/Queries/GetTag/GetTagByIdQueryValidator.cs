using FluentValidation;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTag
{
    public class GetTagByIdQueryValidator : AbstractValidator<GetTagByIdQuery>
    {
        public GetTagByIdQueryValidator()
        {
            RuleFor(getTagByIdQuery => getTagByIdQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
