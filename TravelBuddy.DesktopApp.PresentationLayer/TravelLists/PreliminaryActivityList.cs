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
    public partial class PreliminaryActivityList : Form, IPreliminaryActivityListView
    {
        private readonly ITravelController _travelController;
        private readonly IList<PreliminaryActivity> _preliminaryActivityList;
        private readonly Guid _travelId;
        public PreliminaryActivityList(ITravelController travelController, IList<PreliminaryActivity> preliminaryActivityList, Guid travelId)
        {
            _travelController = travelController;
            _preliminaryActivityList = preliminaryActivityList;
            _travelId = travelId;

            InitializeComponent();
        }

        private void UpdateList()
        {
            listBox.DataSource = _preliminaryActivityList;
            listBox.ValueMember = "Name";
        }

        public void ShowModaless()
        {
            UpdateList();

            Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _travelController.OpenAddPreliminaryActivityWindow(_travelId);
        }
    }
}
