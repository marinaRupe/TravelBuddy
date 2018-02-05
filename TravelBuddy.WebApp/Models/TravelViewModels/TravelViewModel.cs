using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBuddy.Models;
using TravelBuddy.Models.Enums;

namespace TravelBuddy.WebApp.Models.TravelViewModels
{
    public class TravelViewModel
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public MoneyValue Budget { get; set; }
        public string Status { get; set; }

        public TravelViewModel() { }

        public TravelViewModel(Travel travel)
        {
            Name = travel.Name;
            DateStart = travel.DateStart;
            DateEnd = travel.DateEnd;
            Description = travel.Description;
            IsArchived = travel.IsArchived;
            Budget = travel.Budget;
            Status = Enum.GetName(typeof(TravelStatus), travel.GetTravelStatus());
        }
    }
}
