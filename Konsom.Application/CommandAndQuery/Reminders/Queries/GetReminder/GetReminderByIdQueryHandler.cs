using AutoMapper;
using FluentValidation.Results;
using Konsom.Application.Interfaces;
using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder
{
    public class GetReminderByIdQueryHandler : IRequestHandler<GetReminderByIdQuery, ReminderDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReminderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
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

                var reminderFromDb = await _unitOfWork.ReminderRepository.GetById(request.Id);

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
