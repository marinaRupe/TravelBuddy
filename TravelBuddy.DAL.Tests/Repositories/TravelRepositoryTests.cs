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
        private IUnitOfWork _unitOfWork;
        private ITravelRepository _repository;
        
        [TestInitialize()]
        public void SetUp()
        {
            _unitOfWork = new UnitOfWork();
            _repository = new TravelRepository(_unitOfWork);
            _unitOfWork.BeginTransaction();
        }

        [TestCleanup()]
        public void TearDown()
        {
            _unitOfWork.Commit();
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