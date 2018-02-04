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
        private readonly IUnitOfWork _unitOfWork;
        protected ISession Session => _unitOfWork.Session;

        public CurrencyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCurrenciesIfNoneExist()
        {
            var currenciesCount = Session.QueryOver<Currency>().RowCount();
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
                Session.Save(curr);
            }
        }

        public IList<Currency> GetAll()
        {
            return Session.QueryOver<Currency>().List();
        }

        public Currency GetByShortcut(string shortcut)
        {
            var query = Session.QueryOver<Currency>().Where(c => c.Shortcut == shortcut).Take(1);
            return query.SingleOrDefault();
        }

        public Currency GetById(Guid id)
        {
            return Session.Get<Currency>(id);
        }

        public void AddCurrency(Currency currency)
        {
            Session.Save(currency);
        }

        public void UpdateCurrency(Currency currency)
        {
            Session.Update(currency);
        }

        public void DeleteCurrency(Guid currencyId)
        {
            var currency = Session.Get<Currency>(currencyId);

            if (currency != null)
            {
                Session.Delete(currency);
            }
        }
    }
}
