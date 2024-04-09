using AutoMapper;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTags;
using Konsom.Application.Interfaces;
using Konsom.Application.Mapping;
using Konsom.Application.Models.Dto;
using Konsom.UnitTests.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Konsom.UnitTests.Tags.Queries
{
    public class GetTagHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagRepository> _mockRepo;

        public GetTagHandlerTests()
        {
            _mockRepo = MockTagRepository.GetTagRepository();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTagListTest()
        {
            var handler = new GetTagsQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetTagsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<TagDTO>>();

            result.Count.ShouldBe(3);
        }
    }
}
