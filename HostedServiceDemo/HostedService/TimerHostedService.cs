using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServiceDemo.HostedService
{
    public class TimerHostedService : BackgroundService
    {
        private readonly ILogger _logger;

        public TimerHostedService(ILogger<TimerHostedService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("### Proccess executing ###");
                _logger.LogInformation($"{DateTime.Now}");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
