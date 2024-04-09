using AutoMapper;
using Konsom.Application.CommandAndQuery.Tags.Commands.AddTag;
using Konsom.Application.Interfaces;
using Konsom.Application.Mapping;
using Konsom.UnitTests.Mock;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Konsom.UnitTests.Tags.Commands
{
    public class CreateTagCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AddTagCommand _command;
        private readonly AddTagCommandHandler _handler;

        public CreateTagCommandHandlerTests()
        {
            _mockUow = MockTagUnitOfWork.GerUnitOfWork();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new AddTagCommandHandler(_mockUow.Object, _mapper);

            _command = new AddTagCommand
            {
                Name = "TestName"
            };
        }

        [Fact]
        public async Task Valid_Tag_Added()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            var tag = await _mockUow.Object.TagRepository.GetAllAsync();

            result.ShouldBeOfType<Unit>();
        }

        [Fact]
        public async Task InValid_Note_Added()
        {
            _command.Name = "Test";

            var result = await _handler.Handle(_command, CancellationToken.None);

            var tags = await _mockUow.Object.TagRepository.GetAllAsync();

            tags.Count.ShouldBe(4);

            result.ShouldBeOfType<Unit>();
        }
    }
}
