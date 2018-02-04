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
using System.Collections;

namespace TravelBuddy.DAL.Repositories.Tests
{
    [TestClass()]
    public class TravelRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private ITravelRepository _repository;

        public void OpenTestSession()
        {
            _unitOfWork = new UnitOfWork();
            _repository = new TravelRepository(_unitOfWork);
            _unitOfWork.BeginTransaction();
        }

        public void CloseTestSession()
        {
            _unitOfWork.Commit();
        }

        [TestInitialize()]
        public void SetUp()
        {
            OpenTestSession();
        }

        [TestCleanup()]
        public void TearDown()
        {
            var created = _unitOfWork.Session.Query<Travel>();
            foreach (var item in created)
            {
                _unitOfWork.Session.Delete(item);
            }
            CloseTestSession();
        }

        [TestMethod()]
        public void GetTravelIfNotExist()
        {
            Assert.AreEqual(null, _repository.GetTravel(default(Guid)));
        }

        [TestMethod()]
        public void AddTravelTest()
        {
            var travel = new Travel
            {
                Name = "My Travel"
            };
            Assert.AreEqual(null, _repository.GetTravel(travel.Id));
            _repository.AddTravel(travel);
            Assert.AreEqual(travel, _repository.GetTravel(travel.Id));
        }

        [TestMethod()]
        public void UpdateTravelTest()
        {
            var travel = new Travel
            {
                Name = "My Travel"
            };
            _repository.AddTravel(travel);
            CloseTestSession();
            
            travel.Name = "My First Travel";

            OpenTestSession();
            Assert.AreEqual(travel, _repository.GetTravel(travel.Id));
            Assert.AreNotEqual(travel.Name, _repository.GetTravel(travel.Id).Name);
            CloseTestSession();

            OpenTestSession();
            _repository.UpdateTravel(travel);
            Assert.AreEqual(travel, _repository.GetTravel(travel.Id));
            Assert.AreEqual(travel.Name, _repository.GetTravel(travel.Id).Name);
        }

        [TestMethod()]
        public void DeleteTravelTest()
        {
            var travel = new Travel
            {
                Name = "My Travel"
            };
            _repository.AddTravel(travel);
            Assert.AreEqual(travel, _repository.GetTravel(travel.Id));

            _repository.DeleteTravel(travel.Id);
            Assert.AreEqual(null, _repository.GetTravel(travel.Id));
        }

        [TestMethod()]
        public void DeleteTravelIfNotExistTest()
        {
            var travelId = default(Guid);
            Assert.AreEqual(null, _repository.GetTravel(travelId));
            _repository.DeleteTravel(travelId);
            Assert.AreEqual(null, _repository.GetTravel(travelId));
        }

        [TestMethod()]
        public void AddActivityToCostsTest()
        {
            var travel = new Travel
            {
                Name = "My Travel"
            };
            var activity = new TravelActivity
            {
                Name = "My Activity"
            };
            travel.ActivityList.Add(activity);
            _repository.AddTravel(travel);
            Assert.AreEqual(1, _repository.GetTravel(travel.Id).ActivityList.Count);
            Assert.AreEqual(0, _repository.GetTravel(travel.Id).CostList.Count);
            CollectionAssert.AreEqual(travel.ActivityList as ICollection, _repository.GetTravel(travel.Id).ActivityList as ICollection);

            var cost = new MoneyValue
            {
                Value = 24.0,
                Currency = null
            };
            _repository.AddActivityToCosts(travel.Id, activity, cost);
            Assert.AreEqual(0, _repository.GetTravel(travel.Id).ActivityList.Count);
            Assert.AreEqual(1, _repository.GetTravel(travel.Id).CostList.Count);
        }

        [TestMethod()]
        public void RemoveActivityFromCostsTest()
        {
            var travel = new Travel
            {
                Name = "My Travel"
            };
            var activityWithCost = new TravelActivityWithCost
            {
                Name = "My Activity",
                Cost = new MoneyValue
                {
                    Value = 24.0,
                    Currency = null
                }
            };
            travel.CostList.Add(activityWithCost);
            _repository.AddTravel(travel);
            Assert.AreEqual(0, _repository.GetTravel(travel.Id).ActivityList.Count);
            Assert.AreEqual(1, _repository.GetTravel(travel.Id).CostList.Count);
            CollectionAssert.AreEqual(travel.CostList as ICollection, _repository.GetTravel(travel.Id).CostList as ICollection);

            _repository.RemoveActivityFromCosts(travel.Id, activityWithCost);
            Assert.AreEqual(1, _repository.GetTravel(travel.Id).ActivityList.Count);
            Assert.AreEqual(0, _repository.GetTravel(travel.Id).CostList.Count);
        }
    }
}