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

        public void Add(Currency currency)
        {
            _currentSession.Save(currency);
        }
    }
}
