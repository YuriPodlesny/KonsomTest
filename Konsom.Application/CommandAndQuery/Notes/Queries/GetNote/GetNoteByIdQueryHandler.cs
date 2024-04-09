using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
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
            try
            {
                var getNoteQueryValidator = new GetNoteByIdQueryValidator();
                ValidationResult result = getNoteQueryValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }
                var noteFromDb = await _repository.GetById(request.Id);

                if (noteFromDb == null)
                {
                    throw new Exception("Данные не найдены");
                }

                return _mapper.Map<NoteDTO>(noteFromDb);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
