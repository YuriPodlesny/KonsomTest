using AutoMapper;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder
{
    public class AddReminderCommandHandler : IRequestHandler<AddReminderCommand, Unit>
    {
        private readonly IReminderRepository _repository;
        private readonly IMapper _mapper;

        public AddReminderCommandHandler(IReminderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddReminderCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(_mapper.Map<Reminder>(request));
            return Unit.Value;
        }
    }
}
