using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public class Currency
    {
        public virtual string Name { get; set; }
        public virtual string Shortcut { get; set; }
        public virtual double ValueRelativeToUSD { get; set; }
    }
}
