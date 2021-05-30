using Downtown.Core.Models;
using Downtown.Data.Entities;

namespace Downtown.Data.Repositories
{
    public class CityRepository : BaseDataEntityRepository<City, DataCity>, ICityRepository
    {
        public CityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}