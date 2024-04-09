using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTag
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTagByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TagDTO> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getTagQueryValidator = new GetTagByIdQueryValidator();
                ValidationResult result = getTagQueryValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }
                var tagFromDb = await _unitOfWork.TagRepository.GetById(request.Id);

                if (tagFromDb == null)
                {
                    throw new Exception("Данные не найдены");
                }

                return _mapper.Map<TagDTO>(tagFromDb);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
