using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class TravelActivity : Activity, ILocatable
    {
        public virtual Location Location { get; set; }

        public TravelActivity() : base()
        {
        }

        public TravelActivity(string name) : base(name)
        {
        }
    }
}
