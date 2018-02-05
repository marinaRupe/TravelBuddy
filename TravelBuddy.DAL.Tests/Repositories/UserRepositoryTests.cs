using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBuddy.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Models.Repositories;
using TravelBuddy.Models;
using TravelBuddy.Models.Exceptions;

namespace TravelBuddy.DAL.Repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _repository;

        public void OpenTestSession()
        {
            _unitOfWork = new UnitOfWork();
            _repository = new UserRepository(_unitOfWork);
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
            var created = _unitOfWork.Session.Query<User>();
            foreach (var item in created)
            {
                _unitOfWork.Session.Delete(item);
            }
            CloseTestSession();
        }

        [TestMethod()]
        public void GetUserIfNotExitTest()
        {
            Assert.AreEqual(null, _repository.GetUser(default(Guid)));
        }

        [TestMethod()]
        public void AddUserTest()
        {
            var user = new User
            {
                Username = "AddZvone"
            };
            _repository.AddUser(user);
            Assert.AreEqual(user, _repository.GetUser(user.Id));
        }

        [TestMethod()]
        [ExpectedException(typeof(DuplicateUserException))]
        public void AddUserThrowsDuplicateUserExceptionOnUsernameTest()
        {
            var user = new User
            {
                Username = "AddZvone"
            };
            _repository.AddUser(user);
            var newUser = new User
            {
                Username = user.Username
            };
            _repository.AddUser(newUser);
        }

        [TestMethod()]
        [ExpectedException(typeof(DuplicateUserException))]
        public void AddUserThrowsDuplicateUserExceptionOnEmailTest()
        {
            var user = new User
            {
                Email = "AddZvone@fer.com"
            };
            _repository.AddUser(user);
            var newUser = new User
            {
                Email = user.Email
            };
            _repository.AddUser(newUser);
        }

        [TestMethod()]
        public void AddUserSamePasswordTestTest()
        {
            var password = "neka-super.kul+sifra";
            var user = new User
            {
                Username = "AddZvone",
            };
            user.SetPassword(password);
            _repository.AddUser(user);
            Assert.IsTrue(_repository.GetUser(user.Id).IsSamePassword(password));
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            var user = new User
            {
                Username = "UpdateZvone"
            };
            _repository.AddUser(user);
            Assert.AreEqual(user, _repository.GetUser(user.Id));
            CloseTestSession();

            user.Username = "UpdateToZv0n3";

            OpenTestSession();
            Assert.AreEqual(user, _repository.GetUser(user.Id));
            Assert.AreNotEqual(user.Username, _repository.GetUser(user.Id).Username);
            CloseTestSession();

            OpenTestSession();
            _repository.UpdateUser(user);
            Assert.AreEqual(user, _repository.GetUser(user.Id));
            Assert.AreEqual(user.Username, _repository.GetUser(user.Id).Username);
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            var user = new User
            {
                Username = "DeleteZvone"
            };
            _repository.AddUser(user);
            Assert.AreEqual(user, _repository.GetUser(user.Id));

            _repository.DeleteUser(user.Id);
            Assert.AreEqual(null, _repository.GetUser(user.Id));
        }

        [TestMethod()]
        public void DeleteUserIfNotExistTest()
        {
            var userId = default(Guid);
            Assert.AreEqual(null, _repository.GetUser(userId));
            _repository.DeleteUser(userId);
            Assert.AreEqual(null, _repository.GetUser(userId));
        }

        [TestMethod()]
        public void GetUserByEmailTest()
        {
            var user = new User
            {
                Username = "ZvoneEmail",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.AreEqual(user, _repository.GetUserByEmail(user.Email));
        }

        [TestMethod()]
        public void GetUserByEmailCaseInsensitiveTest()
        {
            var user = new User
            {
                Username = "ZvoneEmail",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.AreEqual(user, _repository.GetUserByEmail(user.Email.ToUpper()));
        }

        [TestMethod()]
        public void GetUserByEmailSQLLikeInjectionProofTest()
        {
            var user = new User
            {
                Username = "ZvoneEmail",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.AreNotEqual(user, _repository.GetUserByEmail("%@%"));
        }

        [TestMethod()]
        public void GetUserByUsernameTest()
        {
            var user = new User
            {
                Username = "ZvoneUsername",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.AreEqual(user, _repository.GetUserByUsername(user.Username));
        }

        [TestMethod()]
        public void DoesUserExistTest()
        {
            var user = new User
            {
                Username = "Zvone",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.IsTrue(_repository.DoesUserExist(user.Email, user.Username));
        }

        [TestMethod()]
        public void DoesUserExistEmailOnlyTest()
        {
            var user = new User
            {
                Username = "Zvone",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.IsTrue(_repository.DoesUserExist(email: user.Email));
        }

        [TestMethod()]
        public void DoesUserExistEmailOnlyCaseInsensitiveTest()
        {
            var user = new User
            {
                Username = "Zvone",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.IsTrue(_repository.DoesUserExist(email: user.Email.ToUpper()));
        }

        [TestMethod()]
        public void DoesUserExistUsernameOnlyTest()
        {
            var user = new User
            {
                Username = "Zvone",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.IsTrue(_repository.DoesUserExist(username: user.Username));
        }

        [TestMethod()]
        public void DoesUserExistFakeEmailTest()
        {
            var user = new User
            {
                Username = "Zvone",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.IsFalse(_repository.DoesUserExist("fake", user.Username));
        }

        [TestMethod()]
        public void DoesUserExistFakeUsernameTest()
        {
            var user = new User
            {
                Username = "Zvone",
                Email = "zvone@fer.hr"
            };
            _repository.AddUser(user);
            Assert.IsFalse(_repository.DoesUserExist(user.Email ,"fake"));
        }
    }
}