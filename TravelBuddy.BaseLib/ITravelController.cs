﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.DesktopApp.ViewModels;
using TravelBuddy.Models;

namespace TravelBuddy.BaseLib
{
    public interface ITravelController
    {
        void EditTravel(EditTravelViewModel travel);
        void SaveEditedTravel(EditTravelViewModel travelModel);
        void AddTravel(AddTravelViewModel travel);
        void DeleteTravel(Guid travelId);
        void OpenAddTravelWindow();
        void OpenTravelDetails(Guid travelId);

        void OpenTravelItemListWindow(Guid travelId);
        void OpenPreliminaryListWindow(Guid travelId);
        void OpenCostListWindow(Guid travelId);
        void OpenTravelActivityListWindow(Guid travelId);

        void OpenAddTravelItemWindow(Guid travelId);
        void AddTravelItem(AddTravelItemViewModel travelItemViewModel, Guid travelId);
        void OpenAddPreliminaryActivityWindow(Guid travelId);
        void AddPreliminaryActivity(AddPreliminaryActivityViewModel travelItemViewModel, Guid travelId);
    }
}
