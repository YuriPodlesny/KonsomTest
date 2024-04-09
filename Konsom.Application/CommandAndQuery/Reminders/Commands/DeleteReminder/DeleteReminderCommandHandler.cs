using FluentValidation.Results;
using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReminderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteReminderCommandValidator = new DeleteReminderCommandValidator();
                ValidationResult result = deleteReminderCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }
                await _unitOfWork.ReminderRepository.Delete(request.Id);
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
