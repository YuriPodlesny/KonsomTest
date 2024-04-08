using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
using Shouldly;

namespace Konsom.Tests.Note.Query
{
    public class GetNotesQueryHandlerTest
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public GetNotesQueryHandlerTest(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Fact]
        public async Task GetNoteQueryHandler_Success()
        {
            // Arrenge
            var handler = new GetNotesQueryHandler(_repository, _mapper);

            // Act
            var result = await handler.Handle(new GetNotesQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<List<NoteDTO>>();
        }
    }
}
