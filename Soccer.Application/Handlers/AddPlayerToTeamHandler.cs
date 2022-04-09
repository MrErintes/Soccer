using MediatR;
using Soccer.Application.Commands;
using Soccer.Application.Mappers;
using Soccer.Application.Responses;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;

namespace Soccer.Application.Handlers
{
    public class DeletePlayerFromTeamHandler : IRequestHandler<DeletePlayerFromTeamCommand, TeamResponse>
    {
        private readonly ITeamRepository _teamRepository;

        public DeletePlayerFromTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamResponse> Handle(DeletePlayerFromTeamCommand request, CancellationToken cancellationToken)
        {
            await _teamRepository.DeletePlayerFromTeam(request.TeamId, request.PlayerId);
            var teamEntity = await _teamRepository.GetByIdAsync(request.TeamId);
            if (teamEntity is null)
            {
                throw new ArgumentException();
            }
            return SoccerMapper.Mapper.Map<TeamResponse>(teamEntity);
        }
    }
}