using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Models.Repositories
{
    public interface ICurrencyRepository
    {
        IList<Currency> GetAll();
        Currency GetByShortcut(string shortcut);
        Currency GetById(Guid id);
        void Add(Currency currency);
    }
}
