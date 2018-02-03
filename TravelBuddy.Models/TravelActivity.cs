using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class TravelActivity : EntityBase<Guid>, ITravelActivity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual DateTime? DateCompleted { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual Location Location { get; set; }

        public TravelActivity() : base(new Guid())
        {
            Description = "";
            IsCompleted = false;
        }

        public TravelActivity(string name) : this()
        {
            Name = name;
        }

        public void ToggleCompleted()
        {
            IsCompleted = !IsCompleted;
            DateCompleted = IsCompleted ? DateTime.Now : null as DateTime?;
        }
    }
}
