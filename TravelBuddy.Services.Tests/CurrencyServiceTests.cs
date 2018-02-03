using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBuddy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Services.Tests
{
    [TestClass()]
    public class CurrencyServiceTests
    {
        [TestMethod()]
        public async Task GetCurrencyRateAsyncTestAsync()
        {
            var service = CurrencyService.GetInstance();
            var date = new DateTime(2000, 1, 3);
            var ofCurrency = "EUR";
            var targetCurrency = "USD";

            var rate = await service.GetCurrencyRateAsync(date, ofCurrency, targetCurrency);
            Assert.AreEqual(0.99108, rate, 1e-14);
        }
    }
}