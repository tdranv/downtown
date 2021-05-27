using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Core.Models;

namespace Planner.Data.Entities
{
    public class DataPlan : IDataEntity<Plan>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static void Map(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<DataPlan> config = modelBuilder.Entity<DataPlan>().ToTable("Plan");
            config.HasKey(x => x.Id);
            config.Property(x => x.Name);
        }

        public void SetProperties(Plan model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
        }

        public Plan ToModel()
        {
            var model = new Plan();
            model.Id = this.Id;
            model.Name = this.Name;

            return model;
        }
    }
}
