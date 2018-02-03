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

        public void ToggleCompleted()
        {
        }

        public void ArchiveTravel(Guid travelId)
        {
            var travel = GetTravel(travelId);
            travel.Archive();
        }
    }
}
