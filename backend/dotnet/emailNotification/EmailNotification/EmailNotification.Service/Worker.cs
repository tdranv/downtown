using EmailNotification.Service.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmailNotification.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly EmailNotificationServer emailNotificationServer;

        public Worker(ILogger<Worker> logger)
        {
            this._logger = logger;
            this.emailNotificationServer = new EmailNotificationServer();

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("credentials.json"),
            });
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                await this.emailNotificationServer.SendEventNotificationEmails();

                int remainingDays = 7;
                await Task.Delay(TimeSpan.FromDays(remainingDays), stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
