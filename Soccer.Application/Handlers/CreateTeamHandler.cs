using MediatR;
using Soccer.Application.Commands;
using Soccer.Application.Mappers;
using Soccer.Application.Responses;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;

namespace Soccer.Application.Handlers
{
    public class CreateTeamHandler : IRequestHandler<CreateTeamCommand, TeamResponse>
    {
        private readonly ITeamRepository _teamRepository;

        public CreateTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var teamEntity = SoccerMapper.Mapper.Map<Team>(request);
            if (teamEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newTeam = await _teamRepository.AddAsync(teamEntity);
            return SoccerMapper.Mapper.Map<TeamResponse>(newTeam);
        }
    }
}
