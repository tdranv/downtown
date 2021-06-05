using Downtown.Core.Models;
using Downtown.Data.Entities;

namespace Downtown.Data.Repositories
{
    public class EventRepository : BaseDataEntityRepository<Event, DataEvent>, IEventRepository
    {
        public EventRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
