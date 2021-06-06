using Hotels.Data.Repositories;
using Hotels.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hotels.WebApi.Controllers
{
    [ApiController]
    [Route("hotels")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels = await this.hotelRepository.GetAllAsync().ConfigureAwait(false);

            return this.Ok(hotels);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await this.hotelRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (hotel is null)
            {
                return this.NotFound();
            }

            return this.Ok(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> InsertHotel(HotelCreateModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var model = input.ToModel();
            await this.hotelRepository.SaveAsync(model).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelById(int id)
        {
            var hotel = await this.hotelRepository.GetByIdAsync(id).ConfigureAwait(false);
            await this.hotelRepository.DeleteAsync(hotel).ConfigureAwait(false);

            return NoContent();
        }
    }
}
