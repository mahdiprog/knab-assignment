using CryptoRate.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CryptoRate.Application.CryptoCurrencies;
using CryptoRate.Application.Currencies;
using CryptoRate.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CryptoRate.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<ViewResult> Index()
        {
            var currencies = await Mediator.Send(new GetAllCryptoCurrenciesQuery()).ConfigureAwait(false);
            ViewBag.AllCurrencies=currencies.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Symbol,
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(CryptoRatesViewModel currency)
        {
            IConfigurationSection currencySection = _configuration.GetSection("AvailableCurrencies");
            var symbols = currencySection.AsEnumerable()
                .Where(c => !string.IsNullOrEmpty(c.Value))
                .Select(c => c.Value);
            
            var currencies = await Mediator.Send(new GetAllCryptoCurrenciesQuery()).ConfigureAwait(false);
            ViewBag.AllCurrencies=currencies.Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Symbol,
            });
            
            var usdPrice = await Mediator.Send(new GetCryptoCurrencyPriceQuery {Symbol = currency.SelectedCryptoCurrency}).ConfigureAwait(false);
            var exchangeRate = await Mediator.Send(new GetExchangeRatesQuery{symbols =symbols}).ConfigureAwait(false);

            CryptoRatesViewModel model = new CryptoRatesViewModel {Prices = new Dictionary<string, decimal>()};

            foreach (var symbol in symbols)
            {
                if(symbol.Equals("usd",StringComparison.InvariantCultureIgnoreCase))
                    model.Prices.Add("USD",usdPrice);
                else
                {
                    var priceWithRate = usdPrice * exchangeRate.Rates[symbol];
                    model.Prices.Add(symbol,priceWithRate);
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
