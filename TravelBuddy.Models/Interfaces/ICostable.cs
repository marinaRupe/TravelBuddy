using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Interfaces
{
    public interface ICostable
    {
        double Value { get; set; }
        string Currency { get; set; }
    }
}
