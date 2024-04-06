using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag
{
    internal class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Unit>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;
        public UpdateTagCommandHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateTagCommandValidator = new UpdateTagCommandValidator();
                ValidationResult result = updateTagCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }
                await _repository.Update(_mapper.Map<Tag>(request));
                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
