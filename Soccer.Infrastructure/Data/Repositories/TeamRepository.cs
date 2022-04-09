using Microsoft.EntityFrameworkCore;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;
using Soccer.Infrastructure.Data.Repositories.Base;

namespace Soccer.Infrastructure.Data.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(SoccerContext soccerContext) : base(soccerContext) { }

        public async Task AddPlayerToTeam(long teamId, long playerId)
        {
            var team = await _soccerContext.Teams.Include(x => x.Players).FirstAsync(x => x.TeamId == teamId);
            var player = await _soccerContext.Players.FindAsync(playerId);
            if (team != null && player != null) 
                team.Players.Add(player);
            await _soccerContext.SaveChangesAsync();
        }

        public async Task DeletePlayerFromTeam(long teamId, long playerId)
        {
            var team = await _soccerContext.Teams.Include(x => x.Players).FirstAsync(x => x.TeamId == teamId);
            var player = await _soccerContext.Players.FindAsync(playerId);
            if (team != null && player != null)
                team.Players.Remove(player);
            await _soccerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeamName(string teamName)
        {
            var team = await _soccerContext.Teams.Include(x => x.Players).FirstAsync(t => t.Name == teamName);
            return team != null ? team.Players : Enumerable.Empty<Player>();
        }

        public override async Task<Team> GetByIdAsync(long id)
        {
            return await _soccerContext.Teams.Include(x => x.Players).FirstAsync(t => t.TeamId == id);
        }
    }
}