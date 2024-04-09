using AutoMapper;
using Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder;
using Konsom.Application.Interfaces;
using Konsom.Application.Mapping;
using Konsom.Domain;
using Konsom.UnitTests.Mock;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Konsom.UnitTests.Reminders.Commands
{
    public class CreateReminderCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AddReminderCommand _command;
        private readonly AddReminderCommandHandler _handler;

        public CreateReminderCommandHandlerTests()
        {
            _mockUow = MockReminderUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new AddReminderCommandHandler(_mockUow.Object, _mapper);

            _command = new AddReminderCommand
            {
                Id = Guid.Parse("38acbb11-1d05-4297-9c90-5eec090717bf"),
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
            };
        }

        [Fact]
        public async Task Valid_Reminder_Added()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            var reminders = await _mockUow.Object.ReminderRepository.GetAllAsync();

            result.ShouldBeOfType<Unit>();

            reminders.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_Reminder_Added()
        {
            var result = await _handler.Handle(_command, CancellationToken.None);

            var reminder = await _mockUow.Object.ReminderRepository.GetAllAsync();

            reminder.Count.ShouldBe(4);

            result.ShouldBeOfType<Unit>();
        }
    }
}
