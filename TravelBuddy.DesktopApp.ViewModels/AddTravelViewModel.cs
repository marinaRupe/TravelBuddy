using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.ViewModels
{
    public class AddTravelViewModel
    {
        public virtual string Name { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime DateEnd { get; set; }
        public virtual string Description { get; set; }
        public virtual MoneyValue Budget { get; set; }

        public AddTravelViewModel()
        {
        }
    }
}
