using AutoMapper;
using Soccer.Application.Commands;
using Soccer.Application.Responses;
using Soccer.Core.Entities;

namespace Soccer.Application.Mappers
{
    public class SoccerMappingProfile : Profile
    {
        public SoccerMappingProfile()
        {
            CreateMap<Player, PlayerResponse>().ReverseMap();
            CreateMap<Player, CreatePlayerCommand>().ReverseMap();

            CreateMap<Team, CreateTeamCommand>().ReverseMap();
            CreateMap<Team, TeamResponse>().ReverseMap();
        }
    }
}
