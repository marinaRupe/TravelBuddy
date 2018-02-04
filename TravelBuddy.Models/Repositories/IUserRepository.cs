using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid userId);
        User GetUserByEmail(string email);
        User GetUserByUsername(string username);
        bool doesUserExist(string email, string username);
    }
}
