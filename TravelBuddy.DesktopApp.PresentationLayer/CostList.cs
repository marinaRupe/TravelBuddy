﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.BaseLib;
using TravelBuddy.BaseLib.Views;
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class CostList : Form, ICostListView
    {
        private readonly ITravelController _travelController;
        private readonly IList<TravelActivityWithCost> _costList;
        public CostList(ITravelController travelController, IList<TravelActivityWithCost> costList)
        {
            _travelController = travelController;
            _costList = costList;

            InitializeComponent();
        }

        private void UpdateList()
        {
            listBox.DataSource = _costList;
            listBox.ValueMember = "Name";
        }

        public void ShowModaless()
        {
            UpdateList();

            Show();
        }
    }
}
