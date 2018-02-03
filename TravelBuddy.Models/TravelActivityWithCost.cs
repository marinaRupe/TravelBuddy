using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class TravelActivityWithCost : Activity, ILocatable, ICostable
    {
        public virtual Location Location { get; set; }
        public virtual MoneyValue Cost { get; set; }

        public TravelActivityWithCost() : base()
        {
        }

        public TravelActivityWithCost(string name) : base(name)
        {
        }
    }
}
