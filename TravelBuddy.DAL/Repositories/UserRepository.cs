using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        protected ISession Session => _unitOfWork.Session;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(Guid userId)
        {
            return Session.Get<User>(userId);
        }

        public void AddUser(User user)
        {
            Session.Save(user);
        }

        public void UpdateUser(User user)
        {
            Session.Update(user);
        }

        public void DeleteUser(Guid userId)
        {
            var user = Session.Get<Travel>(userId);

            if (user != null)
            {
                Session.Delete(user);
            }
        }
    }
}
