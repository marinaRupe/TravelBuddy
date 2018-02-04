using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.DesktopApp.ViewModels;

namespace TravelBuddy.BaseLib
{
    public interface ITravelController
    {
        void AddTravel(AddTravelViewModel travel);
        void OpenAddTravelWindow();
    }
}
