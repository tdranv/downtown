using System;

namespace Downtown.Core.Models
{
    public class Event : IModelEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime HappensOn { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
