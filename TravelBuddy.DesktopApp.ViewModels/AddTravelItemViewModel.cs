﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.DesktopApp.ViewModels
{
    public class AddTravelItemViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTaken { get; set; }

        public AddTravelItemViewModel()
        {
        }
    }
}
