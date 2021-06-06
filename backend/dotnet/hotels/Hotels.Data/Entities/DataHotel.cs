using Hotels.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotels.Data.Entities
{
    public class DataHotel : IDataEntity<Hotel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual DataCity City { get; set;}

        public static void Map(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<DataHotel> config = modelBuilder.Entity<DataHotel>().ToTable("Hotel");
            config.HasKey(x => x.Id);
            config.Property(x => x.Name);
            config.Property(x => x.CityId);

            config.HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId);
        }

        public void SetProperties(Hotel model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.CityId = model.CityId;
        }

        public Hotel ToModel()
        {
            var model = new Hotel();
            model.Id = this.Id;
            model.Name = this.Name;
            model.CityId = this.CityId;

            return model;
        }
    }
}
