using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class TravelActivity : EntityBase<Guid>, ITravelActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public Location Location { get; set; }

        public TravelActivity() : base(new Guid())
        {
            Description = "";
            IsCompleted = false;
        }

        public TravelActivity(string name) : this()
        {
            Name = name;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted) return false;

            IsCompleted = true;
            DateCompleted = DateTime.Now;
            return true;
        }
    }
}
