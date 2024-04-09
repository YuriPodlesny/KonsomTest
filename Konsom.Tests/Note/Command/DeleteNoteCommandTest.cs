using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote;
using Konsom.Application.Interfaces;
using Konsom.Tests.Infrastructure;

namespace Konsom.Tests.Note.Command
{
    public class DeleteNoteCommandTest
    {
        private readonly INoteRepository _repository;
        public DeleteNoteCommandTest(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(_repository);

            // Act
            await handler.Handle(new DeleteNoteCommand(NoteContextFactory.NoteIdForDelete), CancellationToken.None);

            // Assert
            Assert.Null(_repository.GetById(NoteContextFactory.NoteIdForDelete));
        }
    }
}
