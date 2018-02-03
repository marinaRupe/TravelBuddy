using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models
{
    public class Location
    {
        public virtual string Country { get; set; }
        public virtual string Town { get; set; }
        public virtual string Street { get; set; }
        public virtual string FullName { get; set; }
        public virtual double? Latitude { get; set; }
        public virtual double? Longitude { get; set; }
    }
}
