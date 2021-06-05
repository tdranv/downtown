using Microsoft.AspNetCore.Mvc;
using Downtown.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Downtown.Rest.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await this.eventRepository.GetAllAsync().ConfigureAwait(false);

            return this.Ok(events);
        }
    }
}
