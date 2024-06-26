﻿using AutoMapper;
using Konsom.Application.Models.Dto;
using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminders
{
    public class GetRemindersQueryHendler : IRequestHandler<GetRemindersQuery, List<ReminderDTO>>
    {
        private readonly IReminderRepository _repository;
        private readonly IMapper _mapper;

        public GetRemindersQueryHendler(IReminderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReminderDTO>> Handle(GetRemindersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var remindersFromDb = await _repository.GetAllAsync();
                if (remindersFromDb == null)
                {
                    throw new Exception("Данные не найдены");
                }

                return _mapper.Map<List<ReminderDTO>>(remindersFromDb);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
