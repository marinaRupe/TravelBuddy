﻿using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using TravelBuddy.Models.Enums;
using TravelBuddy.Models.Interfaces;

namespace TravelBuddy.Models
{
    public class Travel : EntityBase<Guid>
    {
        public virtual string Name { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime DateEnd { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsArchived { get; set; }
        public virtual double BudgetValue { get; set; }
        public virtual string BudgetCurrency { get; set; }

        public virtual User Traveller { get; set; }
        public virtual IList<Activity> ActivityList { get; set; }
        public virtual IList<TravelActivityWithCost> CostList { get; set; }
        public virtual IList<PreliminaryActivity> PreliminaryActivityList { get; set; }
        public virtual IList<ITravelItem> TravelItemList { get; set; }

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

        public TravelStatus GetTravelStatus()
        {
            if (IsArchived) return TravelStatus.Archived;
            if (DateTime.Now < DateStart) return TravelStatus.Planned;
            return HasEnded() ? TravelStatus.Finished : TravelStatus.Active;
        }


        public bool Archive()
        {
            if (!GetTravelStatus().Equals(TravelStatus.Finished)) return false;

            IsArchived = true;
            return true;
        }

        public bool HasEnded()
        {
            return DateEnd < DateTime.Now;
        }
    }
}
