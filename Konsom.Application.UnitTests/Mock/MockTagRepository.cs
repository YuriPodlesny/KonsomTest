using Konsom.Application.Interfaces;
using Konsom.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.UnitTests.Mock
{
    public static class MockTagRepository
    {
        public static Mock<ITagRepository> GetTagRepository()
        {
            var tagTypes = new List<Tag>
            {
                new Tag
                {
                    Id = Guid.Parse("c4ed64a7-7a13-4f2a-9be0-d4fa02d53c29"),
                    Name = "TestName"
                },
                new Tag
                {
                    Id = Guid.Parse("386b3e3a-d3b0-4a72-ab6f-09ce73893e00"),
                    Name = "TestName"
                },
                new Tag
                {
                    Id = Guid.Parse("4ec31160-e5d1-4f62-9c5c-b53e5e718c6c"),
                    Name = "TestName"
                }
            };

            var mockRepo = new Mock<ITagRepository>();
            mockRepo.Setup(e=>e.GetAllAsync()).ReturnsAsync(tagTypes);

            mockRepo.Setup(e => e.Create(It.IsAny<Tag>())).ReturnsAsync((Tag tagType) =>
            {
                tagTypes.Add(tagType);
                return tagType;
            });

            return mockRepo;
        }
    }
}
