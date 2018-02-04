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
        private readonly ISession _currentSession;

        public UserRepository(ISession session)
        {
            _currentSession = session;
        }

        public User GetUser(Guid userId)
        {
            return _currentSession.Get<User>(userId);
        }

        public void AddUser(User user)
        {
            _currentSession.Save(user);
        }

        public void UpdateUser(User user)
        {
            _currentSession.Update(user);
        }

        public void DeleteUser(Guid userId)
        {
            var user = _currentSession.Get<Travel>(userId);

            if (user != null)
            {
                _currentSession.Delete(user);
            }
        }
    }
}
