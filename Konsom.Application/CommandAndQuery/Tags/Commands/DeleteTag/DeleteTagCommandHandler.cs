using AutoMapper;
using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Unit>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public DeleteTagCommandHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
