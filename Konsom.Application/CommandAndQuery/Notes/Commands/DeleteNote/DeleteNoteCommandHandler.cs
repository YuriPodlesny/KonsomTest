using FluentValidation.Results;
using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteNoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteNoteCommandValidator = new DeleteNoteCommandValidator();
                ValidationResult result = deleteNoteCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }
                await _unitOfWork.NoteRepository.Delete(request.Id);
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
