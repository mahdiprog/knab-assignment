using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CryptoRate.Application.Interfaces;
using CryptoRate.Application.Services;
using CryptoRate.Application.Services.CronJobs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoRate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ICryptoCurrencyService, CryptoCurrencyService>();
            services.AddScoped<IExchangeRateService, ExchangeRateService>();
            services.AddHttpClient<ICryptoCurrencyService, CryptoCurrencyService>();
            services.AddHttpClient<IExchangeRateService, ExchangeRateService>();
            // Add Cron jobs
            services.AddCronJob<GetCryptoCurrencyQuotesCronJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"*/5 * * * * *";
            });
            services.AddCronJob<GetExchangeRatesCronJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                c.CronExpression = @"0 15-20 14 * * *";
            });
            return services;
        }
    }
}
