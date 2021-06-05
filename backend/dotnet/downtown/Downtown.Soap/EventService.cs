using Downtown.Data.Repositories;
using Downtown.Soap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Downtown.Soap
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        public async Task<EventModel[]> GetAllEventsAsync()
        {
            var events = await this.eventRepository.GetAllAsync().ConfigureAwait(false);

            var model = events.Select(x => new EventModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CityId = x.CityId,
                PhotoUrl = x.PhotoUrl,
                HappensOn = x.HappensOn,
                CreatedAt = x.CreatedAt
            }).ToArray();

            return model;
        }
    }
}
