using TravelBuddy.DAL;

namespace TravelBuddy.BaseLib.Factories
{
    public static class UnitOfWorkFactory
    {
        public static IUnitOfWork CreateUnitOfWork() => new UnitOfWork();
    }
}
