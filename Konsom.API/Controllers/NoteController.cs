using AutoMapper;
using Konsom.API.Models;
using Konsom.API.Models.Dto;
using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNote;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Konsom.API.Controllers
{

    [ApiController]
    public class NoteController : ControllerBase
    {
        private APIResponse _response; 
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public NoteController(APIResponse response, IMapper mapper, IMediator mediator)
        {
            _response = new ();
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody] NoteCreateDTO createDTO)
        {
            await _mediator.Send(_mapper.Map<AddNoteCommand>(createDTO), CancellationToken.None);
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Delete([FromBody] Guid id)
        {
            await _mediator.Send(new DeleteNoteCommand(id), CancellationToken.None);
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Update([FromBody] NoteUpdateDTO updateDTO)
        {
            await _mediator.Send(_mapper.Map<UpdateNoteCommand>(updateDTO), CancellationToken.None);
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Get([FromBody] Guid id)
        {
            _response.Result = await _mediator.Send(new GetNoteByIdQuery(id), CancellationToken.None);
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> GetNotes()
        {
            _response.Result = await _mediator.Send(new GetNotesQuery(), CancellationToken.None);
            return _response;
        }
    }
}
