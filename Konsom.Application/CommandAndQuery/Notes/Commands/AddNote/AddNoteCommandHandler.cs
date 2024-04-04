using AutoMapper;
using Konsom.Application.Models.Note;
using Konsom.DAL.Repository;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.AddNote
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, NoteDTO>
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public AddNoteCommandHandler(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NoteDTO> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(_mapper.Map<Note>(request));
            return _mapper.Map<NoteDTO>(request);
        }
    }
}
