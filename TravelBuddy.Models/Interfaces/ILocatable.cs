using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Interfaces
{
    public interface ILocatable
    {
        Location Location { get; set; }
    }
}
