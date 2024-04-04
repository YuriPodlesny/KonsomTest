using AutoMapper;
using Konsom.DAL.Repository;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;
        public UpdateNoteCommandHandler(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(_mapper.Map<Note>(request));
            return Unit.Value;
        }
    }
}
