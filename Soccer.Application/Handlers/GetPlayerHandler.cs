using MediatR;
using Soccer.Application.Commands;
using Soccer.Application.Mappers;
using Soccer.Application.Responses;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;

namespace Soccer.Application.Handlers
{
    public class GetPlayerHandler : IRequestHandler<GetPlayerCommand, PlayerResponse>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetPlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<PlayerResponse> Handle(GetPlayerCommand request, CancellationToken cancellationToken)
        {
            var playerEntity = await _playerRepository.GetByIdAsync(request.PlayerId);
            if (playerEntity is null)
            {
                throw new ArgumentException();
            }
            return SoccerMapper.Mapper.Map<PlayerResponse>(playerEntity);
        }
    }
}
