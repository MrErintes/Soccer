using Soccer.Core.Repositories.Base;

namespace Soccer.Core.Repositories
{
    public interface IPlayerRepository : IRepository<Entities.Player>
    {
        Task<IEnumerable<Entities.Player>> GetPlayersByFirstName(string firstName);
    }
}
