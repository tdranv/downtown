using System;

namespace Downtown.Core.Models
{
    public class Comment : IModelEntity
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}
