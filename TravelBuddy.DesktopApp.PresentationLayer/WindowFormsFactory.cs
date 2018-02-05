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

        public ITravelDetailsView CreateTravelDetailsView(ITravelController travelController,
            TravelViewModel travelModel)
        {
            return new TravelDetails(travelController, travelModel);
        }

        public IAddTravelView CreateAddTravelView(ITravelController travelController, IList<Currency> currencyList)
        {
            return new AddTravel(travelController, currencyList);
        }

        public IEditTravelView CreateEditTravelView(ITravelController travelController, EditTravelViewModel model,
            IList<Currency> currencyList)
        {
            return new EditTravel(travelController, model, currencyList);
        }

        public ITravelItemListView CreateTravelItemListView(ITravelController travelController,
            IList<TravelItem> travelItemList)
        {
            return new TravelItemList(travelController, travelItemList);
        }

        public ITravelActivityListView CreateTravelActivityListView(ITravelController travelController,
            IList<TravelActivity> travelActivityList)
        {
            return new TravelActivityList(travelController, travelActivityList);
        }

        public IPreliminaryActivityListView CreatePreliminaryActivityListView(ITravelController travelController,
            IList<PreliminaryActivity> preliminaryActivityList)
        {
            return new PreliminaryActivityList(travelController, preliminaryActivityList);
        }

        public ICostListView CreateCostListView(ITravelController travelController, IList<TravelActivityWithCost> costList)
        {
            return new CostList(travelController, costList);
        }
    }
}
