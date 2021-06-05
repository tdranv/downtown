using Hotels.Core.Models;
using Hotels.Data.Entities;

namespace Hotels.Data.Repositories
{
    public class HotelRepository : BaseDataEntityRepository<Hotel, DataHotel>, IHotelRepository
    {
        public HotelRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}