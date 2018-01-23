using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using TravelBuddy.Models.Enums;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class Travel : EntityBase<Guid>
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public double BudgetValue { get; set; }
        public string BudgetCurrency { get; set; }

        public User Traveller { get; set; }
        public IList<Activity> ActivityList { get; set; }
        public IList<TravelActivityWithCost> CostList { get; set; }
        public IList<PreliminaryActivity> PreliminaryList { get; set; }

        public Travel() : base(new Guid())
        {
            Description = "";
        }

        public Travel(string name, DateTime dateStart, DateTime dateEnd) : base(new Guid())
        {
            Name = name;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsArchived = false;
        }

        public TravelStatus GeTravelStatus()
        {
            if (IsArchived) return TravelStatus.Archived;
            if (DateTime.Now < DateStart) return TravelStatus.Planned;
            return HasEnded() ? TravelStatus.Finished : TravelStatus.Active;
        }


        public bool Archive()
        {
            if (!GeTravelStatus().Equals(TravelStatus.Finished)) return false;

            IsArchived = true;
            return true;
        }

        public bool HasEnded()
        {
            return DateEnd < DateTime.Now;
        }
    }
}
