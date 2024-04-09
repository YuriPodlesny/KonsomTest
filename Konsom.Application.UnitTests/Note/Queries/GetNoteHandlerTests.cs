using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
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

namespace Konsom.UnitTests.Note.Queries
{
    public class GetNoteHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<INoteRepository> _mockRepo;

        public GetNoteHandlerTests()
        {
            _mockRepo = MockNoteTypeRepository.GetNoteRepository();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetNoteListTest()
        {
            var handler = new GetNotesQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetNotesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<NoteDTO>>();

            result.Count.ShouldBe(3);
        }
    }
}
