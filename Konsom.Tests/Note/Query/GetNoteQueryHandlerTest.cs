using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNote;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
using Konsom.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Tests.Note.Query
{
    public class GetNoteQueryTest
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public GetNoteQueryTest(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Fact]
        public async Task GetNoteQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteByIdQueryHandler(_repository, _mapper);

            //Act
            var result = await handler.Handle(new GetNoteByIdQuery(NoteContextFactory.NoteIdForGet), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteDTO>();
            result.Title.ShouldBe("Test1");
            result.Text.ShouldBe("Test1");
        }
 
    }
}
