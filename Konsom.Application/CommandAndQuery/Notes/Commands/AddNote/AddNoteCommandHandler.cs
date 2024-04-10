using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.AddNote
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, Unit>
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public AddNoteCommandHandler(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var addNoteCommandValidator = new AddNoteCommandValidator();
                ValidationResult result = addNoteCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }

                await _repository.Create(_mapper.Map<Note>(request));
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
