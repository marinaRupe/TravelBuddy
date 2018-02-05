using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.BaseLib;
using TravelBuddy.BaseLib.Views;
using TravelBuddy.DesktopApp.ViewModels;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public class WindowFormsFactory : IWindowFormsFactory
    {
        public ILoginView CreateLoginView(IMainController mainController)
        {
            return new Login(mainController);
        }

        public IRegisterView CreateRegisterView(IMainController mainController)
        {
            return new Register(mainController);
        }

        public IMainView CreateMainView(IMainController mainController)
        {
            return new MainWindow(mainController);
        }

        public ITravelListView CreateTravelListView(ITravelController travelController, IList<Travel> travels)
        {
            return new TravelList(travelController, travels);
        }

        public IAddTravelView CreateAddTravelView(ITravelController travelController, IList<Currency> currencyList)
        {
            return new AddTravel(travelController, currencyList);
        }

        public IEditTravelView CreateEditTravelView(ITravelController travelController, EditTravelViewModel model, IList<Currency> currencyList)
        {
            return new EditTravel(travelController, model, currencyList);
        }
    }
}
