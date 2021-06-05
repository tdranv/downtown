using System.ServiceModel;
using System.Threading.Tasks;

namespace Downtown.Soap.Models
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        public Task<EventModel[]> GetAllEventsAsync();
    }
}
