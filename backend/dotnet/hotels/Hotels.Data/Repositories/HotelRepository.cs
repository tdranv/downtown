using Hotels.Core.Models;
using Hotels.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Data.Repositories
{
    public class HotelRepository : BaseDataEntityRepository<Hotel, DataHotel>, IHotelRepository
    {
        public HotelRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Hotel[]> GetAllHotelsAsync()
        {
            var hotels = await this.GetAllQuery()
                                    .Include(x => x.City)
                                    .ToArrayAsync();

            return hotels.Select(x => x.ToModel()).ToArray();
        }
    }
}