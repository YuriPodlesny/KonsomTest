using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminders;
using Konsom.Application.Interfaces;
using Konsom.Application.Mapping;
using Konsom.Application.Models.Dto;
using Konsom.UnitTests.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Konsom.UnitTests.Reminders.Queries
{
    public class GetReminderHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IReminderRepository> _mockRepo;

        public GetReminderHandlerTests()
        {
            _mockRepo = MockReminderRepository.GetReminderRepository();

            var mapperConfig = new MapperConfiguration(e =>
            {
                e.AddProfile<MappingConfig>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetReminderListTest()
        {
            var handler = new GetRemindersQueryHendler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetRemindersQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ReminderDTO>>();

            result.Count.ShouldBe(3);
        }
    }
}
