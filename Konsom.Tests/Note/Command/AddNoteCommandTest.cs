using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Application.Interfaces;

namespace Konsom.Tests.Note.Command
{
    public class AddNoteCommandTest
    {
        private readonly INoteRepository _repository;

        public AddNoteCommandTest(INoteRepository repository)
        {
            _repository = repository;
        }

        [Fact]
        public async Task AddNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new AddNoteCommandHandler(_repository);
            var noteId = Guid.NewGuid();
            var noteTitle = "testNoteTitle";
            var noteText = "testNoteTest";

            //Act
            await handler.Handle(
                new AddNoteCommand
                {
                    Id = noteId,
                    Title = noteTitle,
                    Text = noteText,
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(await _repository.GetById(noteId));
        }
    }
}
