using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.DesktopApp.ViewModels
{
    public class AddPreliminaryActivityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        public AddPreliminaryActivityViewModel()
        {
        }
    }
}
