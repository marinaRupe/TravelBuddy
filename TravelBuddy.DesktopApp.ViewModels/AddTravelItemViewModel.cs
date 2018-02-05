using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.DesktopApp.ViewModels
{
    public class AddTravelItemViewModel
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsTaken { get; set; }

        public AddTravelItemViewModel()
        {
        }
    }
}
