using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.DAL
{
    public class ActivityRepository<TActivity, TId> where TActivity : IActivity
    {
        public TActivity Get(TId id)
        {
            throw new NotImplementedException();
        }

        public void Update()


    }
}
