using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data
{
    public interface IUnitOfWork
    {
        IQueryable<T> GetAllQuery<T>() where T : class;

        Task<T> GetByIdAsync<T>(object id) where T : class;

        Task MarkAsCreatedAsync<T>(T entity) where T : class;

        void MarkAsUpdatedAsync<T>(T entity) where T : class;

        void MarkAsDeletedAsync<T>(T entity) where T : class;

        Task SaveAllAsync();
    }
}
