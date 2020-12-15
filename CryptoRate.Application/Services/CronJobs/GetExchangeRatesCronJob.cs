using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoRate.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace CryptoRate.Application.Services.CronJobs
{
    public class GetExchangeRatesCronJob: CronJobService
    {
        private readonly ILogger<GetExchangeRatesCronJob> _logger;
        private readonly IExchangeRateService _exchangeRateService;

        public GetExchangeRatesCronJob(IScheduleConfig<GetExchangeRatesCronJob> config,
            ILogger<GetExchangeRatesCronJob> logger,
            IExchangeRateService exchangeRateService)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _exchangeRateService = exchangeRateService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetExchangeRatesCronJob starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {

            return _exchangeRateService.GetLatestRate();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetExchangeRatesCronJob is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}