using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelBuddy.Models;

namespace TravelBuddy.WebApp.Models.TravelViewModels
{
    public class EditTravelViewModel : AddTravelViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public EditTravelViewModel() { }

        public EditTravelViewModel(Travel travel)
        {
            Id = travel.Id;
            Name = travel.Name;
            DateStart = travel.DateStart;
            DateEnd = travel.DateEnd;
            Description = travel.Description;
            BudgetValue = travel.Budget.Value;
            BudgetCurrencyId = travel.Budget.Currency.Id;
        }

        public override Travel ToTravel()
        {
            var travel = base.ToTravel();
            travel.Id = Id;
            return travel;
        }
    }
}
