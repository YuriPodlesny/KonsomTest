using AutoMapper;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;    
using MediatR;

namespace Konsom.Application.CommandAndQuery.Tags.Queries.GetTag
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDTO>
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public GetTagByIdQueryHandler(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TagDTO> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tagFromDb = await _repository.GetById(request.Id);
            return _mapper.Map<TagDTO>(tagFromDb);
        }
    }
}
