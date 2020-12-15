using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoRate.Application.Interfaces;
using CryptoRate.Application.ViewModels;

namespace CryptoRate.Application.Services
{
    public class ExchangeRateService:IExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ExchangeRatePseudo> GetLatestRate(string baseCurrencySymbol="USD")
        {
            var jsonStream = await _httpClient.GetStreamAsync($"https://api.exchangeratesapi.io/latest?base={baseCurrencySymbol}");
            var exchangeRate = await JsonSerializer.DeserializeAsync<ExchangeRatePseudo>(jsonStream);
            return exchangeRate;
        }
    }
}
