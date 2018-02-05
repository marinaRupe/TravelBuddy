using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelBuddy.Models;
using TravelBuddy.Models.Enums;

namespace TravelBuddy.WebApp.Models.TravelViewModels
{
    public class IndexTravelViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Naziv putovanja")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Vrijeme početka")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Vrijeme završetka")]
        public DateTime DateEnd { get; set; }

        public bool IsArchived { get; set; }

        public string Status { get; set; }

        public IndexTravelViewModel() { }

        public IndexTravelViewModel(Travel travel)
        {
            Id = travel.Id;
            Name = travel.Name;
            DateStart = travel.DateStart;
            DateEnd = travel.DateEnd;
            IsArchived = travel.IsArchived;
            Status = Enum.GetName(typeof(TravelStatus), travel.GetTravelStatus());
        }
    }
}
