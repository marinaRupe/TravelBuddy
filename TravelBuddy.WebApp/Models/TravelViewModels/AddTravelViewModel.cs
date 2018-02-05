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
        public string Name { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public MoneyValue Budget { get; set; }
    }
}
