using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBuddy.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Models.Repositories;
using TravelBuddy.Models;
using System.Collections;

namespace TravelBuddy.DAL.Repositories.Tests
{
    [TestClass()]
    public class CurrencyRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private ICurrencyRepository _repository;

        public void OpenTestSession()
        {
            _unitOfWork = new UnitOfWork();
            _repository = new CurrencyRepository(_unitOfWork);
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
            var created = _unitOfWork.Session.Query<Currency>();
            foreach (var item in created)
            {
                _unitOfWork.Session.Delete(item);
            }
            CloseTestSession();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            (_repository as CurrencyRepository).CreateCurrenciesIfNoneExist();
            var fakeRepositoryItems = new List<Currency>
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
            CollectionAssert.AreEqual(
                fakeRepositoryItems.Select(c => new { c.Name, c.Shortcut }).ToList(), 
                _repository.GetAll().Select(c => new { c.Name, c.Shortcut }).ToList()
                );
        }

        [TestMethod()]
        public void GetByShortcutTest()
        {
            var bitcoin = new Currency
            {
                Name = "bitcoin",
                Shortcut = "BTC"
            };
            Assert.AreEqual(null, _repository.GetByShortcut(bitcoin.Shortcut));
            _repository.AddCurrency(bitcoin);
            Assert.AreEqual(bitcoin, _repository.GetByShortcut(bitcoin.Shortcut));
        }

        [TestMethod()]
        public void GetByIdIfNotExistTest()
        {
            Assert.AreEqual(null, _repository.GetById(default(Guid)));
        }

        [TestMethod()]
        public void AddCurrencyTest()
        {
            var bitcoin = new Currency
            {
                Name = "bitcoin",
                Shortcut = "BTC"
            };
            Assert.AreEqual(null, _repository.GetById(bitcoin.Id));
            _repository.AddCurrency(bitcoin);
            Assert.AreEqual(bitcoin, _repository.GetById(bitcoin.Id));
        }

        [TestMethod()]
        public void UpdateCurrencyTest()
        {
            var bitcoin = new Currency
            {
                Name = "bitcoin",
                Shortcut = "BTC"
            };
            _repository.AddCurrency(bitcoin);
            Assert.AreEqual(bitcoin, _repository.GetById(bitcoin.Id));
            CloseTestSession();

            bitcoin.Shortcut = "XBT";

            OpenTestSession();
            Assert.AreEqual(bitcoin, _repository.GetById(bitcoin.Id));
            Assert.AreNotEqual(bitcoin.Shortcut, _repository.GetById(bitcoin.Id).Shortcut);
            CloseTestSession();

            OpenTestSession();
            _repository.UpdateCurrency(bitcoin);
            Assert.AreEqual(bitcoin, _repository.GetById(bitcoin.Id));
            Assert.AreEqual(bitcoin.Shortcut, _repository.GetById(bitcoin.Id).Shortcut);
        }

        [TestMethod()]
        public void DeleteCurrencyTest()
        {
            var bitcoin = new Currency
            {
                Name = "bitcoin",
                Shortcut = "BTC"
            };
            _repository.AddCurrency(bitcoin);
            Assert.AreEqual(bitcoin, _repository.GetById(bitcoin.Id));

            _repository.DeleteCurrency(bitcoin.Id);
            Assert.AreEqual(null, _repository.GetById(bitcoin.Id));
        }

        [TestMethod()]
        public void DeleteCurrencyIfNotExistTest()
        {
            (_repository as CurrencyRepository).CreateCurrenciesIfNoneExist();
            var count = _repository.GetAll().Count;
            var id = default(Guid);
            Assert.AreEqual(null, _repository.GetById(id));
            _repository.DeleteCurrency(id);
            Assert.AreEqual(count, _repository.GetAll().Count);
        }
    }
}