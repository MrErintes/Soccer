namespace Soccer.Core.Repositories.Base
{
    public interface IRepository <T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
