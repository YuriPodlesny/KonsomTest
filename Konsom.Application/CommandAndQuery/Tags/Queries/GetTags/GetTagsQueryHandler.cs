using AutoMapper;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTags
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, List<TagDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTagsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TagDTO>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tagsFromDB = await _unitOfWork.TagRepository.GetAllAsync();
                if (tagsFromDB == null)
                {
                    throw new Exception("Данные не найдены");
                }

                return _mapper.Map<List<TagDTO>>(tagsFromDB);
            }
            catch (Exception)
            {
                throw;
            }         
        }
    }
}
