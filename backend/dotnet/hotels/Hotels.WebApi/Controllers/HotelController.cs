using Hotels.Core.Models;
using Hotels.Data.Repositories;
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

        [HttpGet("getHotelById")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await this.hotelRepository.GetByIdAsync(id).ConfigureAwait(false);

            return this.Ok(hotel);
        }

        [HttpPost("insertHotel")]
        public async Task<IActionResult> InsertHotel(Hotel hotel)
        {
            await this.hotelRepository.InsertHotelAsync(hotel).ConfigureAwait(false);

            return NoContent();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteHotelById(int id)
        {
            var hotel = await this.hotelRepository.GetByIdAsync(id).ConfigureAwait(false);
            await this.hotelRepository.DeleteAsync(hotel).ConfigureAwait(false);

            return NoContent();
        }
    }
}
