using System;
using System.Collections.Generic;
using System.Net.Http;
using TravelBuddy.Models;

namespace TravelBuddy.Services
{
    public class CurrencyService
    {
        private const string API_ADDRESS = @"https://api.fixer.io";
        private static CurrencyService _instance;

        private HttpClient _client;

        private CurrencyService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(API_ADDRESS)
            };
        }

        public CurrencyService GetInstance()
        {
            _instance = _instance ?? new CurrencyService();
            return _instance;
        }

        public IList<Currency> GetLatestCurrencyList()
        {
            return null;
        }
    }
}
