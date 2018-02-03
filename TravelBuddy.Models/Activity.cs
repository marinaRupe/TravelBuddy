using System;
using System.Collections.Generic;
using System.Text;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public abstract class Activity : EntityBase<Guid>, IActivity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual DateTime? DateCompleted { get; set; }
        public virtual DateTime? DueDate { get; set; }

        public Activity() : base()
        {
            Description = "";
            IsCompleted = false;
        }

        public Activity(string name) : this()
        {
            Name = name;
        }

        public virtual void ToggleCompleted()
        {
            IsCompleted = !IsCompleted;
            DateCompleted = IsCompleted ? DateTime.Now : null as DateTime?;
        }
    }
}
