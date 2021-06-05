using Downtown.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Downtown.Data.Entities
{
    public class DataEvent : IDataEntity<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime HappensOn { get; set; }

        public DateTime CreatedAt { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<DataEvent> config = modelBuilder.Entity<DataEvent>().ToTable("events");
            config.HasKey(x => x.Id);
            config.Property(x => x.Name);
            config.Property(x => x.Description);
            config.Property(x => x.CityId).HasColumnName("city_id");
            config.Property(x => x.PhotoUrl).HasColumnName("photo_url");
            config.Property(x => x.HappensOn).HasColumnName("happens_on");
            config.Property(x => x.CreatedAt).HasColumnName("created_at");
        }

        public void SetProperties(Event model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
            this.CityId = model.CityId;
            this.PhotoUrl = model.PhotoUrl;
            this.HappensOn = model.HappensOn;
            this.CreatedAt = model.CreatedAt;
        }

        public Event ToModel()
        {
            var model = new Event();
            model.Id = this.Id;
            model.Name = this.Name;
            model.Description = this.Description;
            model.CityId = this.CityId;
            model.PhotoUrl = this.PhotoUrl;
            model.HappensOn = this.HappensOn;
            model.CreatedAt = this.CreatedAt;

            return model;
        }
    }
}
