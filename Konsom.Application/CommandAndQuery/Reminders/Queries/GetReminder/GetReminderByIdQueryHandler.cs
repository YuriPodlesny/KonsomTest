using AutoMapper;
using Konsom.Application.Models.Reminder;
using Konsom.DAL.Repository;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder
{
    public class GetReminderByIdQueryHandler : IRequestHandler<GetReminderByIdQuery, ReminderDTO>
    {
        private readonly IReminderRepository _repository;
        private readonly IMapper _mapper;

        public GetReminderByIdQueryHandler(IReminderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReminderDTO> Handle(GetReminderByIdQuery request, CancellationToken cancellationToken)
        {
            var reminderFromDb = await _repository.GetById(request.Id);
            return _mapper.Map<ReminderDTO>(reminderFromDb);
        }
    }
}
