using MediatR;
using Soccer.Application.Responses;

namespace Soccer.Application.Commands
{
    public class GetTeamCommand : IRequest<TeamResponse>
    {
        public long TeamId { get; set; }
    }
}
