using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.BaseLib
{
    public interface IWindowFormsFactory
    {
        ILoginView CreateLoginView(IMainController mainController);
        IRegisterView CreateRegisterView(IMainController mainController);
        IMainView CreateMainView(IMainController mainController);
        ITravelListView CreateTravelListView(ITravelController travelController, IList<Travel> travels);
        IAddTravelView CreateAddTravelView(ITravelController travelController);
    }
}
