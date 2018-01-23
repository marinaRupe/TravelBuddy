using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBuddy.Models.Interfaces
{
    public interface IActivity
    {
        string Name { get; set; }
        string Description { get; set; }
        bool IsCompleted { get; set; }
        DateTime DateCompleted { get; set; }
        DateTime DueDate { get; set; }
        bool MarkAsCompleted();
    }
}
