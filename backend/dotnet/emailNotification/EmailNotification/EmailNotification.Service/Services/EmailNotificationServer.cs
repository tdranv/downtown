using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailNotification.Service.Models
{
    public class EmailNotificationServer
    {
        public static void SendEventNotificationEmails()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
            };

            //TODO: add credentials
            smtpClient.UseDefaultCredentials = false;

            //TODO: add "to" email
            //string to = "";
            //TODO: add "from" email
            //string from = "";

            ////MailMessage message = new MailMessage(from, to);
            //message.Subject = "Test";
            //message.Body = @"Using this new feature, you can send an email message from an application very easily.";
           
            //try
            //{
            //    smtpClient.Send(message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
            //        ex.ToString());
            //}
        }
    }
}
