﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.BaseLib.Views;
using TravelBuddy.DesktopApp.ViewModels;
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
        ITravelDetailsView CreateTravelDetailsView(ITravelController travelController, TravelViewModel travelModel);
        IEditTravelView CreateEditTravelView(ITravelController travelController, EditTravelViewModel model, IList<Currency> currencyList);
        IAddTravelView CreateAddTravelView(ITravelController travelController, IList<Currency> currencyList);

        ITravelItemListView CreateTravelItemListView(ITravelController travelController, IList<TravelItem> travelItemList, Guid travelId);
        ITravelActivityListView CreateTravelActivityListView(ITravelController travelController, IList<TravelActivity> travelActivityList, Guid travelId);
        IPreliminaryActivityListView CreatePreliminaryActivityListView(ITravelController travelController,IList<PreliminaryActivity> preliminaryActivityList, Guid travelId);
        ICostListView CreateCostListView(ITravelController travelController, IList<TravelActivityWithCost> costList, Guid travelId);

        IAddTravelItemView CreateAddTravelItemView(ITravelController travelController, Guid travelId);
        IAddPreliminaryItemView CreateAddPreliminaryItemView(ITravelController travelController, Guid travelId);
    }
}
