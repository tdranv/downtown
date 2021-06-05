using EmailNotification.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmailNotification.Service.Services
{
    public class EventService
    {
        static HttpClient client = new HttpClient();

        public static async Task<List<EventModel>> GetEventsAsync()
        {
            client.BaseAddress = new Uri("https://downtown-backend-downtown.azuremicroservices.io/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("events?latest=true");

            List<EventModel> events = null;
            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<List<EventModel>>();
            }
            return events;
        }
    }
}
