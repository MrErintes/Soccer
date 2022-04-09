using Blogs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Soccer.Core.Entities;
using Soccer.Core.Repositories;
using Soccer.Infrastructure.Data.Repositories.Base;

namespace Soccer.Infrastructure.Data.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(SoccerContext soccerContext) : base(soccerContext){}

        public async Task<IEnumerable<Player>> GetPlayersByFirstName(string firstName)
        {
            return await _soccerContext.Players.Where(p => p.FirstName == firstName).ToListAsync();
        }

        public override async Task<Player> GetByIdAsync(long id)
        {
            return await _soccerContext.Players.Include(x => x.Team).FirstAsync(p => p.PlayerId == id);
        }
    }
}
