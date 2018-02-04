using TravelBuddy.DAL;

namespace TravelBuddy.BaseLib.Factories
{
    public class UnitOfWorkFactory
    {
        private static UnitOfWorkFactory _instance;

        private UnitOfWorkFactory() { }

        public static UnitOfWorkFactory GetInstance()
        {
            _instance = _instance ?? new UnitOfWorkFactory();
            return _instance;
        }

        public IUnitOfWork CreateUnitOfWork() => new UnitOfWork();
    }
}
