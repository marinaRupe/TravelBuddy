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

        public User Get(Guid userId)
        {
            return _currentSession.Get<User>(userId);
        }

        public void UpdateUser(User user)
        {
            _currentSession.Update(user);
        }
    }
}
