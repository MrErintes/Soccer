using Soccer.Core.Repositories.Base;

namespace Soccer.Core.Repositories
{
    public interface ITeamRepository : IRepository<Entities.Team>
    {
        Task<IEnumerable<Entities.Player>> GetPlayersByTeamName(string teamName);
        Task AddPlayerToTeam(long teamId, long playerId);
        Task DeletePlayerFromTeam(long teamId, long playerId);
    }
}
