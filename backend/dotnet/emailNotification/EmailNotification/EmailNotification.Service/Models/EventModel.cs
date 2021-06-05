using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotification.Service.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CityModel City { get; set; }

        public string PhotoUrl { get; set; }

        public string Description { get; set; }

        public Int64 HappensOn { get; set; }

        public Int64 CreatedOn { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}
