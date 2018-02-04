using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DAL.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ISession _currentSession;

        public CurrencyRepository(ISession session)
        {
            _currentSession = session;
        }

        public void CreateCurrenciesIfNoneExist()
        {
            var currenciesCount = _currentSession.Query<Currency>().Count();
            if (currenciesCount != 0) return;

            var currencies = new List<Currency>
            {
                new Currency
                {
                    Name = "hrvatska kuna",
                    Shortcut = "HRK"
                },
                new Currency
                {
                    Name = "američki dolar",
                    Shortcut = "USD"
                },
                new Currency
                {
                    Name = "euro",
                    Shortcut = "EUR"
                },
                new Currency
                {
                    Name = "australski dolar",
                    Shortcut = "AUD"
                },
                new Currency
                {
                    Name = "britanska funta",
                    Shortcut = "GBP"
                },
                new Currency
                {
                    Name = "kanadski dolar",
                    Shortcut = "CAD"
                },
                new Currency
                {
                    Name = "švicarski franak",
                    Shortcut = "CHF"
                }
            };

            foreach (var curr in currencies)
            {
                _currentSession.Save(curr);
            }
        }

        public IList<Currency> GetAll()
        {
            return _currentSession.Query<Currency>().ToList();
        }

        public Currency GetByShortcut(string shortcut)
        {
            return _currentSession.Query<Currency>().SingleOrDefault(c => c.Shortcut == shortcut);
        }

        public Currency GetById(Guid id)
        {
            return _currentSession.Get<Currency>(id);
        }

        public void AddCurrency(Currency currency)
        {
            _currentSession.Save(currency);
        }

        public void UpdateCurrency(Currency currency)
        {
            _currentSession.Update(currency);
        }

        public void DeleteCurrency(Guid currencyId)
        {
            var currency = _currentSession.Get<Travel>(currencyId);

            if (currency != null)
            {
                _currentSession.Delete(currency);
            }
        }
    }
}
