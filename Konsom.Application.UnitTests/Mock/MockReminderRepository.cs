using Konsom.Application.Interfaces;
using Konsom.Domain;
using Moq;

namespace Konsom.UnitTests.Mock
{
    public static class MockReminderRepository
    {
        public static Mock<IReminderRepository> GetReminderRepository()
        {
            var reminderTypes = new List<Reminder>
            {
                new Reminder
                {
                    Id = Guid.Parse("1bc525cf-1834-4175-ad7d-8da27bf8e733"),
                    Title = "TestTitle",
                    Text = "TestText",
                    Time = DateTime.Today,
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
                new Reminder
                {
                    Id = Guid.Parse("c9e3bfe6-03d7-4a22-a954-239e7a35cc99"),
                    Title = "TestTitle",
                    Text = "TestText",
                    Time = DateTime.Today,
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
                new Reminder
                {
                    Id = Guid.Parse("7cc02d0b-b74a-469c-a319-40c6de47b692"),
                    Title = "TestTitle",
                    Text = "TestText",
                    Time = DateTime.Today,
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
            };

            var mockRepo = new Mock<IReminderRepository>();
            mockRepo.Setup(e => e.GetAllAsync()).ReturnsAsync(reminderTypes);

            mockRepo.Setup(e => e.Create(It.IsAny<Reminder>())).ReturnsAsync((Reminder reminderType) =>
            {
                reminderTypes.Add(reminderType);
                return reminderType;
            });

            return mockRepo;
        }
    }
}
