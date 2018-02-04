using TravelBuddy.DAL;
using TravelBuddy.DAL.Repositories;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.BaseLib.Factories
{
    public static class RepositoriesFactory
    {
        public static ITravelRepository CreateTravelRepository(IUnitOfWork unitOfWork) => new TravelRepository(unitOfWork);

        public static IUserRepository CreateUserRepository(IUnitOfWork unitOfWork) => new UserRepository(unitOfWork);

        public static ICurrencyRepository CreateCurrencyRepository(IUnitOfWork unitOfWork) => new CurrencyRepository(unitOfWork);
    }
}
