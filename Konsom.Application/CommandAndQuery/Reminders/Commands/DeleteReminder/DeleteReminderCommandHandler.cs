using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, Unit>
    {
        private readonly IReminderRepository _repository;

        public DeleteReminderCommandHandler(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
