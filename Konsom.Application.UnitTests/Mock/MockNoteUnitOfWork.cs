using Konsom.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.UnitTests.Mock
{
    public static class MockNoteUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockNoteTypeRepo = MockNoteTypeRepository.GetNoteRepository();

            mockUow.Setup(x=>x.NoteRepository).Returns(mockNoteTypeRepo.Object);

            return mockUow;
        }
    }
}
