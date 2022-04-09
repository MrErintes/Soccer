using MediatR;
using Soccer.Application.Responses;

namespace Soccer.Application.Commands
{
    public class CreatePlayerCommand : IRequest<PlayerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
