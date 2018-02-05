using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelBuddy.Models;

namespace TravelBuddy.WebApp.Models.TravelViewModels
{
    public class AddTravelViewModel
    {
        [Required]
        [Display(Name = "Naziv putovanja")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vrijeme početka")]
        public DateTime DateStart { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vrijeme završetka")]
        public DateTime DateEnd { get; set; } = DateTime.Now.AddDays(7);

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Iznos budžeta")]
        public double BudgetValue { get; set; }

        [Display(Name = "Valuta budžeta")]
        public Guid BudgetCurrencyId { get; set; }

        public IEnumerable<Currency> CurrencyOptions { get; set; }

        public virtual Travel ToTravel()
        {
            return new Travel
            {
                Name = Name,
                DateStart = DateStart,
                DateEnd = DateEnd,
                Description = Description
            };
        }
    }
}
