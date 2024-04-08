using Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminders;
using Konsom.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Konsom.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/reminder")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private APIResponse _response;
        private readonly IMediator _mediator;

        public ReminderController(IMediator mediator)
        {
            _response = new();
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Create([FromBody] AddReminderCommand create)
        {
            try
            {
                await _mediator.Send(create, CancellationToken.None);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Delete([FromBody] Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteReminderCommand(id), CancellationToken.None);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Update([FromBody] UpdateReminderCommand update)
        {
            try
            {
                await _mediator.Send(update, CancellationToken.None);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
        }

        [HttpPost("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetReminder([FromBody] Guid id)
        {
            try
            {
                _response.Result = await _mediator.Send(new GetReminderByIdQuery(id), CancellationToken.None);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
        }

        [HttpPost("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetReminders()
        {
            try
            {
                _response.Result = await _mediator.Send(new GetRemindersQuery(), CancellationToken.None);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return BadRequest(_response);
            }
        }

    }
}
