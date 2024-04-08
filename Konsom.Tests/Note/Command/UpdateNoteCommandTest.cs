using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote;
using Konsom.Application.Interfaces;
using Konsom.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Tests.Note.Command
{
    public class UpdateNoteCommandTest
    {
        private readonly INoteRepository _repository;
        private readonly IMapper _mapper;

        public UpdateNoteCommandTest(INoteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_Succes()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler(_repository, _mapper);
            var updateTitle = "new Title";

            //Act
            await handler.Handle(new UpdateNoteCommand
            {
                Id = NoteContextFactory.NoteIdForUpdate,
                Title = updateTitle
            }, CancellationToken.None);

            //Assert
            var resut = await _repository.GetById(NoteContextFactory.NoteIdForUpdate);
            Assert.NotNull(resut);
            Assert.DoesNotContain(resut.Title, updateTitle);
        }
    }
}
