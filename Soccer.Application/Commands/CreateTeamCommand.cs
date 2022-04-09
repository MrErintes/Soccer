using MediatR;
using Soccer.Application.Responses;

namespace Soccer.Application.Commands
{
    public class CreateTeamCommand : IRequest<TeamResponse>
    {
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string ManagerEmail { get; set; }
    }
}
