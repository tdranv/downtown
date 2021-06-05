using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Downtown.Core.Models;

namespace Downtown.Data.Entities
{
    public class DataCity : IDataEntity<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<DataCity> config = modelBuilder.Entity<DataCity>().ToTable("cities");
            config.HasKey(x => x.Id);
            config.Property(x => x.Name);
        }

        public void SetProperties(City model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
        }

        public City ToModel()
        {
            var model = new City();
            model.Id = this.Id;
            model.Name = this.Name;

            return model;
        }
    }
}
