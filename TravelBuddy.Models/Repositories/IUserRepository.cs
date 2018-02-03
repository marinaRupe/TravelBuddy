using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid userId);
        void UpdateUser(User user);
    }
}
