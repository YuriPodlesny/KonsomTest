using AutoMapper;
using Konsom.Application.CommandAndQuery.Tags.Commands.AddTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.DeleteTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTag;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTags;
using Konsom.Application.Models;
using Konsom.Application.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Konsom.API.Controllers
{
    [Route("api/v{version:apiVersion}/function/tag")]
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

        [HttpPost("create")]
        public async Task<ActionResult<APIResponse>> Create([FromBody] TagCreateDTO createDTO)
        {
            await _mediator.Send(_mapper.Map<AddTagCommand>(createDTO), CancellationToken.None);
            return Ok(_response);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<APIResponse>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTagCommand(id), CancellationToken.None);
            return Ok(_response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<APIResponse>> Update([FromBody] TagUpdateDTO updateDTO)
        {
            await _mediator.Send(_mapper.Map<UpdateTagCommand>(updateDTO), CancellationToken.None);
            return Ok(_response);
        }

        [HttpGet("get")]
        public async Task<ActionResult<APIResponse>> GetTag(Guid id)
        {
            _response.Result = await _mediator.Send(new GetTagByIdQuery(id), CancellationToken.None);
            return Ok(_response);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<APIResponse>> GetTags()
        {
            _response.Result = await _mediator.Send(new GetTagsQuery(), CancellationToken.None);
            return Ok(_response);
        }
    }
}
