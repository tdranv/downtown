using Downtown.Core;
using Downtown.Core.Models;
using System.Threading.Tasks;

namespace Downtown.Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment[]> GetByEventId(int eventId); 
    }
}
