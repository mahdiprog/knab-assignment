using System.Threading.Tasks;
using CryptoRate.Application.ViewModels;

namespace CryptoRate.Application.Interfaces
{
    public interface IExchangeRateService
    {
        Task<ExchangeRatePseudo> GetLatestRate(string baseCurrencySymbol = "USD");
    }
}