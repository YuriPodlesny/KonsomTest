using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote
{
    internal class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INoteRepository _repository;
        public DeleteNoteCommandHandler(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
