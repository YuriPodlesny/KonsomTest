using AutoMapper;
using Konsom.API.Models;
using Konsom.API.Models.Dto;
using Konsom.Application.CommandAndQuery.Tags.Commands.AddTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.DeleteTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTag;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Konsom.API.Controllers
{
    [ApiController]
    public class TagController : ControllerBase
    {
        private APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TagController(IMapper mapper, IMediator mediator)
        {
            _response = new();
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody] TagCreateDTO createDTO)
        {
            await _mediator.Send(_mapper.Map<AddTagCommand>(createDTO), CancellationToken.None);
            return Ok(_response);
        }

        
        public async Task<ActionResult<APIResponse>> Delete([FromBody] Guid id)
        {
            await _mediator.Send(new DeleteTagCommand(id), CancellationToken.None);
            return Ok(_response);
        }

        public async Task<ActionResult<APIResponse>> Update([FromBody] TagUpdateDTO updateDTO)
        {
            await _mediator.Send(_mapper.Map<UpdateTagCommand>(updateDTO), CancellationToken.None);
            return Ok(_response);
        }

        public async Task<ActionResult<APIResponse>> GetTag([FromBody] Guid id)
        {
            _response.Result = await _mediator.Send(new GetTagByIdQuery(id), CancellationToken.None);
            return Ok(_response);
        }

        public async Task<ActionResult<APIResponse>> GetTags()
        {
            _response.Result = await _mediator.Send(new GetTagsQuery(), CancellationToken.None);
            return Ok(_response);
        }
    }
}
