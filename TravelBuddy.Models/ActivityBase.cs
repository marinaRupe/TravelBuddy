using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public abstract class ActivityBase : IActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public bool MarkAsCompleted()
        {
            if (IsCompleted) return false;

            IsCompleted = true;
            DateCompleted = DateTime.Now;
            return true;
        }
    }
}
