using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Interfaces
{
    interface ITravelActivity : IActivity
    {
        Location Location { get; set; }
    }
}
