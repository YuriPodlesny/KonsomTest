using Konsom.Application.Interfaces;
using Moq;

namespace Konsom.UnitTests.Mock
{
    public static class MockNoteUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockNoteTypeRepo = MockNoteTypeRepository.GetNoteRepository();

            mockUow.Setup(x => x.NoteRepository).Returns(mockNoteTypeRepo.Object);

            return mockUow;
        }
    }
}
