using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNote;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
using Konsom.Application.Models;
using Konsom.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Konsom.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public NoteController(IMapper mapper, IMediator mediator)
        {
            _response = new();
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<APIResponse>> Create([FromBody] NoteCreateDTO createDTO)
        {
            await _mediator.Send(_mapper.Map<AddNoteCommand>(createDTO), CancellationToken.None);
            return _response;
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<APIResponse>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteNoteCommand(id), CancellationToken.None);
            return _response;
        }

        [HttpPut("update")]
        public async Task<ActionResult<APIResponse>> Update([FromBody] NoteUpdateDTO updateDTO)
        {
            await _mediator.Send(_mapper.Map<UpdateNoteCommand>(updateDTO), CancellationToken.None);
            return _response;
        }

        [HttpGet("get")]
        public async Task<ActionResult<APIResponse>> GetNote(Guid id)
        {
            _response.Result = await _mediator.Send(new GetNoteByIdQuery(id), CancellationToken.None);
            return _response;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<APIResponse>> GetNotes()
        {
            _response.Result = await _mediator.Send(new GetNotesQuery(), CancellationToken.None);
            return _response;
        }
    }
}
