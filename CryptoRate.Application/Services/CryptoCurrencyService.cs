using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoRate.Application.Interfaces;
using CryptoRate.Application.ViewModels;
using CryptoRate.Domain.Interfaces;
using CryptoRate.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CryptoRate.Application.Services
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private readonly string _remoteServiceBaseUrl;
        private readonly TimeSpan _slidingExpiration = TimeSpan.FromSeconds(2);

        public CryptoCurrencyService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "dbf60d2e-709f-4590-9b99-4537e30f962c");
        }

        public async Task<IEnumerable<CryptoCurrencyPseudo>> FetchLatestQuoteAndSetCache(params string[] symbols)
        {
            var quotes = (await RequestLatestQuotes(symbols)).ToList();
            foreach (var quote in quotes)
            {
                _cache.Set($"{quote.Symbol}-Price", quote.Quote.Usd.Price, new MemoryCacheEntryOptions{SlidingExpiration = _slidingExpiration});
            }
            // Save data in cache.
           
            return quotes;
        }

        private async Task<IEnumerable<CryptoCurrencyPseudo>> RequestLatestQuotes(params string[] symbols)
        {
            var jsonStream =
                await _httpClient.GetStreamAsync(
                    $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?aux=is_active&symbol={string.Join(",",symbols)}").ConfigureAwait(false);
            var coinInfo = await CoinMarketCapResponse<CryptoCurrencyPseudo>.FromJson(jsonStream).ConfigureAwait(false);
            return coinInfo.Data;
        }
        private async Task<CryptoCurrencyPseudo> RequestLatestQuote(string symbol)
        {
            return (await RequestLatestQuotes(symbol)).FirstOrDefault();
        }

        public async Task<CryptoCurrencyPseudo> GetLatestQuote(string symbol)
        {
            var cacheKey = $"{symbol}-Price";
            var quote = await _cache.GetOrCreateAsync(cacheKey,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = _slidingExpiration;
                    return Task.Run(() => RequestLatestQuote(symbol));
                }).ConfigureAwait(false);
            return quote;
        }

        public async Task<IEnumerable<CryptoCurrency>> GetAllCurrencies()
        {
            var cacheKey = "symbols";

            var quote = await _cache.GetOrCreateAsync(cacheKey,
                cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromDays(1);
                    return Task.Run(RequestAllCurrencies);
                }).ConfigureAwait(false);
            return quote;
        }
        private async Task<IEnumerable<CryptoCurrency>> RequestAllCurrencies()
        {

            var response = 
                await _httpClient.GetFromJsonAsync<CoinMarketCapResponse<CryptoCurrency>>(
                    $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/map?limit=20&aux=").ConfigureAwait(false);
            return response.Data;
        }
    }
}
