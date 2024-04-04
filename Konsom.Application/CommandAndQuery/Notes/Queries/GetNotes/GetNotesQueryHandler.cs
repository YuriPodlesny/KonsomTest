using AutoMapper;
using Konsom.Application.Models.Note;
using Konsom.DAL.Repository;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<NoteDTO>>
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public GetNotesQueryHandler(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<NoteDTO>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var notesFromDb = await _repository.GetAllAsync();
            return _mapper.Map<List<NoteDTO>>(notesFromDb);
        }
    }
}
