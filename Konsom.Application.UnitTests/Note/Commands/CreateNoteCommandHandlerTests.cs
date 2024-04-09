using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Application.Interfaces;
using Konsom.Application.Mapping;
using Konsom.Domain;
using Konsom.UnitTests.Mock;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Konsom.UnitTests.Note.Commands
{
    public class CreateNoteCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AddNoteCommand _command;
        private readonly AddNoteCommandHandler _handler;

        public CreateNoteCommandHandlerTests()
        {
            _mockUow = MockNoteUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new AddNoteCommandHandler(_mockUow.Object, _mapper);

            _command = new AddNoteCommand
            {
                Id = Guid.Parse("1bc525cf-1834-4175-ad7d-8da27bf8e733"),
                Text = "Test1",
                Title = "Test1",
                Tags = new List<Tag>
                {
                    new Tag
                    {
                        Id = Guid.Parse("29fb1752-fdcf-475c-8681-f70efc7e50d2"),
                        Name = "TegTast1"
                    },
                    new Tag
                    {
                        Id = Guid.Parse("cb28c008-8566-4516-abf6-4ac137eef013"),
                        Name = "TegTest2"
                    }
                },
            };
        }

        [Fact]
        public async Task Valid_Note_Added()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            var notes = await _mockUow.Object.NoteRepository.GetAllAsync();

            result.ShouldBeOfType<Unit>();

            notes.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Note_Added()
        {
            _command.Text = "Test";

            var result = await _handler.Handle(_command, CancellationToken.None);

            var notes = await _mockUow.Object.NoteRepository.GetAllAsync();

            notes.Count.ShouldBe(4);

            result.ShouldBeOfType<Unit>();
        }
    }
}
