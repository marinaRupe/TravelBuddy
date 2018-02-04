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
        private readonly IUnitOfWork _unitOfWork;
        protected ISession Session => _unitOfWork.Session;

        public TravelRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Travel GetTravel(Guid travelId)
        {
            return Session.Get<Travel>(travelId);
        }

        public void AddTravel(Travel travel)
        {
            Session.Save(travel);
        }

        public void UpdateTravel(Travel travel)
        {
            Session.Update(travel);
        }
        public void DeleteTravel(Guid travelId)
        {
            var travel = Session.Get<Travel>(travelId);

            if (travel != null)
            {
                Session.Delete(travel);
            }
        }

        public void AddActivityToCosts(Guid travelId, TravelActivity activity, MoneyValue cost)
        {
            var travel = Session.Get<Travel>(travelId);
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

            Session.Update(travel);
        }

        public void RemoveActivityFromCosts(Guid travelId, TravelActivityWithCost activityWithCost)
        {
            var travel = Session.Get<Travel>(travelId);
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

            Session.Update(travel);
        }
    }
}
