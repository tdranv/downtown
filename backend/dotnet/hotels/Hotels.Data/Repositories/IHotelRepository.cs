using Hotels.Core;
using Hotels.Core.Models;
using System.Threading.Tasks;

namespace Hotels.Data.Repositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<Hotel[]> GetAllHotelsAsync();
    }
}