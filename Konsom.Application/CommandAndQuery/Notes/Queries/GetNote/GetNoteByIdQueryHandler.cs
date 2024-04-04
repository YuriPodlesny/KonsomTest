using AutoMapper;
using Konsom.Application.Models.Note;
using Konsom.DAL.Repository;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNote
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, NoteDTO>
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public GetNoteByIdQueryHandler(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NoteDTO> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var noteFromDb = await _repository.GetById(request.Id);
            return _mapper.Map<NoteDTO>(noteFromDb);
        }
    }
}
