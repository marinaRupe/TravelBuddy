using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using NHibernate;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DAL.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ISession _currentSession;

        public TravelRepository(ISession session)
        {
            _currentSession = session;
        }

        public Travel GetTravel(Guid travelId)
        {
            return _currentSession.Get<Travel>(travelId);
        }

        public void AddTravel(Travel travel)
        {
            _currentSession.Save(travel);
        }

        public void UpdateTravel(Travel travel)
        {
            _currentSession.Update(travel);
        }
        public void DeleteTravel(Guid travelId)
        {
            var travel = _currentSession.Get<Travel>(travelId);

            if (travel != null)
            {
                _currentSession.Delete(travel);
            }
        }

        public void AddActivityToCosts(Guid travelId, TravelActivity activity, MoneyValue cost)
        {
            var travel = _currentSession.Get<Travel>(travelId);
            var activityWithCost = new TravelActivityWithCost
            {
                Name = activity.Name,
                Description = activity.Description,
                IsCompleted = activity.IsCompleted,
                DateCompleted = activity.DateCompleted,
                DueDate = activity.DueDate,
                Cost = cost
            };

            travel.CostList.Add(activityWithCost);
            travel.ActivityList.Remove(activity);

            _currentSession.Update(travel);
        }

        public void RemoveActivityFromCosts(Guid travelId, TravelActivityWithCost activityWithCost)
        {
            var travel = _currentSession.Get<Travel>(travelId);
            var activity = new TravelActivity
            {
                Name = activityWithCost.Name,
                Description = activityWithCost.Description,
                IsCompleted = activityWithCost.IsCompleted,
                DateCompleted = activityWithCost.DateCompleted,
                DueDate = activityWithCost.DueDate
            };

            travel.ActivityList.Add(activity);
            travel.CostList.Remove(activityWithCost);

            _currentSession.Update(travel);
        }
    }
}
