namespace Hotels.Core.Models
{
    public class Hotel : IModelEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
