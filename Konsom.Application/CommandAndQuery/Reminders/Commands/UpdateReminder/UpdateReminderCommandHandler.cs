using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder
{
    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, Unit>
    {
        private readonly IReminderRepository _repository;
        private readonly IMapper _mapper;

        public UpdateReminderCommandHandler(IReminderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateReminderCommandValidator = new UpdateReminderCommandValidator();
                ValidationResult result = updateReminderCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }
                await _repository.Update(_mapper.Map<Reminder>(request));
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
