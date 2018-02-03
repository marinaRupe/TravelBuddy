using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBuddy.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using TravelBuddy.Models.Repositories;
using TravelBuddy.Models;

namespace TravelBuddy.DAL.Repositories.Tests
{
    [TestClass()]
    public class TravelRepositoryTests
    {
        static ISessionFactory _factory;
        ISession _session;
        ITransaction _transaction;
        ITravelRepository _repository;

        [ClassInitialize()]
        public static void Init(TestContext context)
        {
            _factory = SessionFactory.GetSessionFactory();
        }

        [TestInitialize()]
        public void SetUp()
        {
            _session = _factory.OpenSession();
            _repository = new TravelRepository(_session);
            _transaction = _session.BeginTransaction();
        }

        [TestCleanup()]
        public void TearDown()
        {
            // TODO: Update with UnitOfWork
            try
            {
                if (_transaction != null && _transaction.IsActive) _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive) _transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Dispose();
            }
        }

        [TestMethod()]
        public void AddTravelTest()
        {
            var travel = new Travel
            {
                Name = "My Travel"
            };
            _repository.AddTravel(travel);
            Assert.AreEqual(travel, _repository.GetTravel(travel.Id));
        }
    }
}