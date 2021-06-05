using EmailNotification.Service.Models;
using EmailNotification.Service.Services;
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

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                EmailNotificationServer.SendEventNotificationEmails();

                int remainingDays = 7;
                await Task.Delay(TimeSpan.FromDays(remainingDays), stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
