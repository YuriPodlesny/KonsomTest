using Konsom.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.UnitTests.Mock
{
    public static class MockReminderUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockReminderTypeRepo = MockReminderRepository.GetReminderRepository();

            mockUow.Setup(e=>e.ReminderRepository).Returns(mockReminderTypeRepo.Object);

            return mockUow;
        }
    }
}
