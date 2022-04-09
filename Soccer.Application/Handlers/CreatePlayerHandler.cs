using MediatR;
using Soccer.Application.Commands;
using Soccer.Application.Mappers;
using Soccer.Application.Responses;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;

namespace Soccer.Application.Handlers
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, PlayerResponse>
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayerResponse> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var playerEntity = SoccerMapper.Mapper.Map<Player>(request);
            if (playerEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newPlayer = await _playerRepository.AddAsync(playerEntity);
            var playerResponse = SoccerMapper.Mapper.Map<PlayerResponse>(newPlayer);
            return playerResponse;
        }
    }
}
