using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Repositories
{
    public interface ITravelRepository
    {
        Travel GetTravel(Guid travelId);
        void AddTravel(Travel travel);
        void UpdateTravel(Travel travel);
        void DeleteTravel(Guid travelId);
        void AddActivityToCosts(Guid travelId, TravelActivity activity, MoneyValue cost);
        void RemoveActivityFromCosts(Guid travelId, TravelActivityWithCost activityWithCost);
    }
}
