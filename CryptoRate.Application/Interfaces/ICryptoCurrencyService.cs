using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoRate.Application.ViewModels;
using CryptoRate.Domain.Interfaces;
using CryptoRate.Domain.Models;

namespace CryptoRate.Application.Interfaces
{
    public interface ICryptoCurrencyService
    {
        Task<IEnumerable<CryptoCurrencyPseudo>> FetchLatestQuoteAndSetCache(params string[] symbols);
        Task<CryptoCurrencyPseudo> GetLatestQuote(string symbol);
        Task<IEnumerable<CryptoCurrency>> GetAllCurrencies();
    }
}
