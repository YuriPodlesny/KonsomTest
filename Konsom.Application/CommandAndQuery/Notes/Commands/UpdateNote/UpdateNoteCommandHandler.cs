using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
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
            try
            {
                var updateNoteCommandValidator = new UpdateNoteCommandValidator();
                ValidationResult result = updateNoteCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }

                await _repository.Update(_mapper.Map<Note>(request));
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
