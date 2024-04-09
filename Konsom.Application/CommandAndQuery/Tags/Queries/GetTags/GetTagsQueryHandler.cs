using AutoMapper;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTags
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, List<TagDTO>>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagsQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TagDTO>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tagsFromDB = await _repository.GetAllAsync();
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
