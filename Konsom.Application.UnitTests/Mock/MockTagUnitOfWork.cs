using Konsom.Application.Interfaces;
using Moq;

namespace Konsom.UnitTests.Mock
{
    public static class MockTagUnitOfWork
    {
        public static Mock<IUnitOfWork> GerUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockTagTypeRepo = MockTagRepository.GetTagRepository();

            mockUow.Setup(e => e.TagRepository).Returns(mockTagTypeRepo.Object);

            return mockUow;
        }

    }
}
