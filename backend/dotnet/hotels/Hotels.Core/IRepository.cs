using System.Threading.Tasks;

namespace Hotels.Core
{
    public interface IRepository<T>
            where T : IModelEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<T> SaveAsync(T entity);

        Task<T[]> SaveAsync(params T[] entities);

        Task<T[]> GetAllAsync();

        Task DeleteAsync(params T[] entities);
    }
}
