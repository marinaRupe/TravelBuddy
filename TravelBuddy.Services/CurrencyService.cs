using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TravelBuddy.Models;
using TravelBuddy.Services.DataTransferObjects.Fixer;

namespace TravelBuddy.Services
{
    public class CurrencyService
    {
        private const string API_ADDRESS = @"https://api.fixer.io";
        private static CurrencyService _instance;

        private readonly HttpClient _client;

        private CurrencyService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(API_ADDRESS)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static CurrencyService GetInstance()
        {
            _instance = _instance ?? new CurrencyService();
            return _instance;
        }

        public async Task<double> GetCurrencyRateAsync(DateTime atDate, string ofCurrencyShortcut, string toTargetCurrencyShortcut)
        {
            var queryString = $"/{atDate.ToString("yyyy-MM-dd")}?base={toTargetCurrencyShortcut.ToUpper()}&symbols={ofCurrencyShortcut.ToUpper()}";
            var response = await _client.GetAsync(queryString);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            var content = await response.Content.ReadAsAsync<ExchangeRatesObject>();
            return content.Rates.Select(rate => rate.Value).First();
        }
    }
}
