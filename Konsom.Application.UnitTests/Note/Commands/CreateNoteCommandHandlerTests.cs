using AutoMapper;
using Konsom.Application.Interfaces;
using Konsom.Application.Mapping;
using Konsom.Application.CommandAndQuery.Notes;
using Konsom.UnitTests.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Domain;
using Xunit;
using Shouldly;
using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.UnitTests.Note.Commands
{
    public class CreateNoteCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AddNoteCommand _addNote;
        private readonly AddNoteCommandHandler _handler;

        public CreateNoteCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new AddNoteCommandHandler(_mockUow.Object, _mapper);

            _addNote = new AddNoteCommand
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
            var result = await _handler.Handle(_addNote, CancellationToken.None);

            var notes = await _mockUow.Object.NoteRepository.GetAllAsync();

            result.ShouldBeOfType<Unit>();
        }

        [Fact]
        public async Task InValid_Note_Added()
        {
            _addNote.Text = "TegTast1";

            var result = await _handler.Handle(_addNote, CancellationToken.None);

            var notes = await _mockUow.Object.NoteRepository.GetAllAsync();

            notes.Count.ShouldBe(4);

            result.ShouldBeOfType<Unit>();
        }
    }
}
