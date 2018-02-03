using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public class Currency : EntityBase<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Shortcut { get; set; }

        public Currency() : base(new Guid())
        {
        }

        public Currency(string name, string shortcut) : this()
        {
            Name = name;
            Shortcut = shortcut;
        }
    }
}
