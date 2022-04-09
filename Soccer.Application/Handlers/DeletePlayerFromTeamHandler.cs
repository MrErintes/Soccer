using MediatR;
using Soccer.Application.Commands;
using Soccer.Application.Mappers;
using Soccer.Application.Responses;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;

namespace Soccer.Application.Handlers
{
    public class AddPlayerToTeamHandler : IRequestHandler<AddPlayerToTeamCommand, TeamResponse>
    {
        private readonly ITeamRepository _teamRepository;

        public AddPlayerToTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamResponse> Handle(AddPlayerToTeamCommand request, CancellationToken cancellationToken)
        {
            await _teamRepository.AddPlayerToTeam(request.TeamId, request.PlayerId);
            var teamEntity = await _teamRepository.GetByIdAsync(request.TeamId);
            if (teamEntity is null)
            {
                throw new ArgumentException();
            }
            return SoccerMapper.Mapper.Map<TeamResponse>(teamEntity);
        }
    }
}