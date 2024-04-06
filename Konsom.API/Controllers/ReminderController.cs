using AutoMapper;
using Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminders;
using Konsom.Application.Models;
using Konsom.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Konsom.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/reminder")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ReminderController(IMapper mapper, IMediator mediator)
        {
            _response = new();
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<APIResponse>> Create([FromBody] ReminderCreateDTO createDTO)
        {
            await _mediator.Send(_mapper.Map<AddReminderCommand>(createDTO), CancellationToken.None);
            return _response;
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<APIResponse>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteReminderCommand(id), CancellationToken.None);
            return _response;
        }

        [HttpPut("update")]
        public async Task<ActionResult<APIResponse>> Update([FromBody] ReminderUpdateDTO updateDTO)
        {
            await _mediator.Send(_mapper.Map<UpdateReminderCommand>(updateDTO), CancellationToken.None);
            return _response;
        }

        [HttpGet("get")]
        public async Task<ActionResult<APIResponse>> GetReminder(Guid id)
        {
            _response.Result = await _mediator.Send(new GetReminderByIdQuery(id), CancellationToken.None);
            return _response;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<APIResponse>> GetReminders()
        {
            _response.Result = await _mediator.Send(new GetRemindersQuery(), CancellationToken.None);
            return _response;
        }

    }
}
