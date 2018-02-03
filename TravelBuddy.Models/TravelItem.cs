using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class TravelItem : EntityBase<Guid>, ITravelItem
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsTaken { get; set; }
        public virtual string Label { get; set; }

        public TravelItem() : base()
        {
            IsTaken = false;
            Description = "";
            Label = "";
        }

        public TravelItem(string name) : this()
        {
            Name = name;
        }

        public virtual void ToggleTaken()
        {
            IsTaken = !IsTaken;
        }
    }
}
