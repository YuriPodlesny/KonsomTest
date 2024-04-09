using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Commands.AddTag
{
    public class AddTagCommandHandler : IRequestHandler<AddTagCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var addTagCommandValidator = new AddTagCommandValidator();
                ValidationResult result = addTagCommandValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }

                await _unitOfWork.TagRepository.Create(_mapper.Map<Tag>(request));
            }
            catch (Exception)
            {
                throw;
            }
    
            return Unit.Value;
        }
    }
}
