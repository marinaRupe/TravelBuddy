using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DAL
{
    public class TravelRepository : ITravelRepository
    {
        private static TravelRepository _instance;
        private IList<Travel> _travels;

        private TravelRepository()
        {
            _travels = new List<Travel>();
        }

        public static TravelRepository GetInstance()
        {
            return _instance ?? (_instance = new TravelRepository());
        }

        public void Add(Travel travel)
        {
            _travels.Add(travel);
        }

        public Travel GetTravel(Guid travelId)
        {
            var item = _travels.FirstOrDefault(t => t.Id.Equals(travelId));
            return item;
        }

        public void UpdateTravel(Travel travel)
        {
            // Save
        }

        public void ToggleCompleted()
        {
        }

        public void ArchiveTravel(Guid travelId)
        {
            var travel = GetTravel(travelId);
            travel.Archive();
        }

        public void Remove(Travel travel)
        {
            _travels.Remove(travel);
        }
    }
}
