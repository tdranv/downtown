using System;
using System.Runtime.Serialization;

namespace Downtown.Soap.Models
{
    [DataContract]
    public class EventModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int CityId { get; set; }

        [DataMember]
        public string PhotoUrl { get; set; }

        [DataMember]
        public DateTime HappensOn { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
