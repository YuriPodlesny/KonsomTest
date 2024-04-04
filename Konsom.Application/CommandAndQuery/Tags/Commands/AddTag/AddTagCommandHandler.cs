using AutoMapper;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.AddTag
{
    public class AddTagCommandHandler : IRequestHandler<AddTagCommand, Unit>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public AddTagCommandHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(_mapper.Map<Tag>(request));
            return Unit.Value;
        }
    }
}
