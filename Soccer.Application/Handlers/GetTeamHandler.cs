using MediatR;
using Soccer.Application.Commands;
using Soccer.Application.Mappers;
using Soccer.Application.Responses;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;

namespace Soccer.Application.Handlers
{
    public class GetTeamHandler : IRequestHandler<GetTeamCommand, TeamResponse>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<TeamResponse> Handle(GetTeamCommand request, CancellationToken cancellationToken)
        {
            var teamEntity = await _teamRepository.GetByIdAsync(request.TeamId);
            if (teamEntity is null)
            {
                throw new ArgumentException();
            }
            return SoccerMapper.Mapper.Map<TeamResponse>(teamEntity);
        }
    }
}
