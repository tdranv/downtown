using Hotels.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hotels.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("hotels")]
    public class PlanController : ControllerBase
    {
        private readonly IHotelRepository hotelRepository;

        public PlanController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //HttpContext.VerifyUserHasAnyAcceptedScope(RequiredScopes);
            var hotels = await this.hotelRepository.GetAllAsync().ConfigureAwait(false);

            return this.Ok(hotels);
        }
    }
}
