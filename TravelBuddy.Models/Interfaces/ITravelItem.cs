using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Interfaces
{
    public interface ITravelItem
    {
        string Name { get; set; }
        string Description { get; set; }
        bool IsTaken { get; set; }
        string Label { get; set; }
        void ToggleTaken();
    }
}
