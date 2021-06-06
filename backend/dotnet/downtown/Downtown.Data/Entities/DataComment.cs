using Downtown.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Downtown.Data.Entities
{
    public class DataComment : IDataEntity<Comment>
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<DataComment> config = modelBuilder.Entity<DataComment>().ToTable("comments");
            config.HasKey(x => x.Id);
            config.Property(x => x.Id).HasColumnName("comment_id");
            config.Property(x => x.EventId).HasColumnName("event_id");
            config.Property(x => x.UserName);
            config.Property(x => x.Content);
            config.Property(x => x.Date);
        }

        public void SetProperties(Comment model)
        {
            this.Id = model.Id;
            this.EventId = model.EventId;
            this.UserName = model.UserName;
            this.Content = model.Content;
            this.Date = model.Date;
        }

        public Comment ToModel()
        {
            var model = new Comment();
            model.Id = this.Id;
            model.EventId = this.EventId;
            model.UserName = this.UserName;
            model.Content = this.Content;
            model.Date = this.Date;

            return model;
        }
    }
}
