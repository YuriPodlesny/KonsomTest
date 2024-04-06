using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
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
            try
            {
                var getReminderQueryValidator = new GetReminderByIdQueryValidator();
                ValidationResult result = getReminderQueryValidator.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception("Данные не валидны");
                }

                var reminderFromDb = await _repository.GetById(request.Id);

                if (reminderFromDb == null)
                {
                    throw new Exception("Данные не найдены");
                }
                return _mapper.Map<ReminderDTO>(reminderFromDb);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
