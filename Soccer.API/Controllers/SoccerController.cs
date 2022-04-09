using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soccer.Application.Commands;
using Soccer.Application.Responses;

namespace Soccer.API.Controllers
{
    [ApiController]
    public class SoccerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SoccerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/CreatePlayer")]
        public async Task<ActionResult<PlayerResponse>> CreatePlayer([FromBody] CreatePlayerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/CreateTeam")]
        public async Task<ActionResult<TeamResponse>> CreateTeam([FromBody] CreateTeamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/GetPlayer")]
        public async Task<ActionResult<PlayerResponse>> GetPlayer([FromQuery] GetPlayerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/GetTeam")]
        public async Task<ActionResult<TeamResponse>> GetTeam([FromQuery] GetTeamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/AddPlayerToTeam")]
        public async Task<ActionResult<TeamResponse>> AddPlayerToTeam([FromQuery] AddPlayerToTeamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/DeletePlayerFromTeam")]
        public async Task<ActionResult<TeamResponse>> DeletePlayerFromTeam([FromQuery] DeletePlayerFromTeamCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
