using System;

namespace EmailNotification.Service.Models
{
    public class EventModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime HappensOn { get; set; }
    }
}
