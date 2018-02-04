using TravelBuddy.DAL;
using TravelBuddy.DAL.Repositories;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.BaseLib.Factories
{
    public class RepositoriesFactory
    {
        private static RepositoriesFactory _instance;

        private RepositoriesFactory() { }

        public static RepositoriesFactory GetInstance()
        {
            _instance = _instance ?? new RepositoriesFactory();
            return _instance;
        }

        public ITravelRepository CreateTravelRepository(IUnitOfWork unitOfWork) => new TravelRepository(unitOfWork);

        public IUserRepository CreateUserRepository(IUnitOfWork unitOfWork) => new UserRepository(unitOfWork);

        public ICurrencyRepository CreateCurrencyRepository(IUnitOfWork unitOfWork) => new CurrencyRepository(unitOfWork);
    }
}
