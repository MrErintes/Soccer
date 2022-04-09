using MediatR;
using Soccer.Application.Responses;

namespace Soccer.Application.Commands
{
    public class GetPlayerCommand : IRequest<PlayerResponse>
    {
        public long PlayerId { get; set; }
    }
}
