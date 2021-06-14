using EmailNotification.Service.Services;
using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailNotification.Service.Models
{
    public class EmailNotificationServer
    {
        private readonly EventService eventService;

        public EmailNotificationServer()
        {
            this.eventService = new EventService();
        }

        public async Task SendEventNotificationEmails()
        {
            var smtpClient = new SmtpClient("localhost", 25);

            var events = await this.eventService.GetEventsAsync().ConfigureAwait(false);
            var topEvents = events.Take(10);

            // Iterate through all users. This will still retrieve users in batches,
            // buffering no more than 1000 users in memory at a time.
            var enumerator = FirebaseAuth.DefaultInstance.ListUsersAsync(null).GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                MailMessage message = new MailMessage("admin@downdown.app", enumerator.Current.Email);
                message.Subject = "Latest Events";

                message.Body = this.BuildMailBody(topEvents);

                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
                }
            }

            ////TODO: add credentials
            //smtpClient.UseDefaultCredentials = false;
        }

        private string BuildMailBody(IEnumerable<EventModel> events)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Latest events:");

            foreach (var eventModel in events)
            {
                sb.AppendLine($"{eventModel.Name} on {eventModel.HappensOn}");
            }

            return sb.ToString();
        }
    }
}
