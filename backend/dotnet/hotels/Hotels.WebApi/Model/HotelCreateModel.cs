using Hotels.Core.Models;

namespace Hotels.WebApi.Model
{
    public class HotelCreateModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public Hotel ToModel()
        {
            Hotel hotel = new Hotel()
            {
                Id = this.Id,
                Name = this.Name,
                CityId = this.CityId,
            };

            return hotel;
        }
    }
}
