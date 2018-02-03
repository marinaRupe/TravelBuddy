using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public class MoneyValue
    {
        public virtual double Value { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
