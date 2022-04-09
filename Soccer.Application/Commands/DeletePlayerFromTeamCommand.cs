using MediatR;
using Soccer.Application.Responses;

namespace Soccer.Application.Commands
{
    public class DeletePlayerFromTeamCommand : IRequest<TeamResponse>
    {
        public long PlayerId { get; set; }
        public long TeamId { get; set; }
    }
}
