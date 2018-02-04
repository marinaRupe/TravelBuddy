using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.BaseLib
{
    public interface IMainController
    {
        void Login(string username, string password);
        void Register(string username, string email, string password);
        void Logout();
        void ShowRegisterWindow();
        void OpenTravelListWindow();
        Guid LoggedInUserId { get; }
        bool IsUserLoggedIn();
    }
}
