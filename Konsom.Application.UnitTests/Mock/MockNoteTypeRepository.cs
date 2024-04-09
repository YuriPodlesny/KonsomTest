using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konsom.Application.Interfaces;
using Konsom.Domain;
using Moq;

namespace Konsom.UnitTests.Mock
{
    public static class MockNoteTypeRepository
    {
        public static Mock<INoteRepository> GetNoteRepository()
        {
            var noteTypes = new List<Domain.Note>
            {
                new Domain.Note
                {
                    Id = Guid.Parse("0feeaa3f-d0e6-4bc8-a930-bfe05fc8181c"),
                    Text = "Test1",
                    Title = "Test1",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = Guid.Parse("29fb1752-fdcf-475c-8681-f70efc7e50d2"),
                            Name = "TegTast1"
                        },
                        new Tag
                        {
                            Id = Guid.Parse("cb28c008-8566-4516-abf6-4ac137eef013"),
                            Name = "TegTest2"
                        }
                    }
                },
                new Domain.Note
                {
                    Id = Guid.Parse("26a2297e-53f9-4c29-9d17-7e8a97a2a106"),
                    Text = "Test2",
                    Title = "Test2",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = Guid.Parse("dc564d2b-ce4b-4800-abc2-ed38b5ffabd6"),
                            Name = "TegTast3"
                        },
                        new Tag
                        {
                            Id = Guid.Parse("123ee992-1c32-430d-bf4f-9d3c5ef588d6"),
                            Name = "TegTest4"
                        }
                    }
                },
                new Domain.Note
                {
                    Id = Guid.Parse("e5815e46-e6b5-43c7-ba98-daf8d2b4be38"),
                    Text = "Test1",
                    Title = "Test1",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = Guid.Parse("29fb1752-fdcf-475c-8681-f70efc7e50d2"),
                            Name = "TegTast1"
                        },
                        new Tag
                        {
                            Id = Guid.Parse("cb28c008-8566-4516-abf6-4ac137eef013"),
                            Name = "TegTest2"
                        }
                    }
                }
            };

            var mockRepo = new Mock<INoteRepository>();
            mockRepo.Setup(e => e.GetAllAsync()).ReturnsAsync(noteTypes);

            mockRepo.Setup(e => e.Create(It.IsAny<Domain.Note>())).Returns((Domain.Note noteType) =>
            {
                noteTypes.Add(noteType);
                return noteType;
            });

            return mockRepo;
        }
    }
}
