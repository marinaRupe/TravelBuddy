﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.ViewModels
{
    public class AddTravelViewModel
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public MoneyValue Budget { get; set; }

        public AddTravelViewModel()
        {
        }
    }
}
