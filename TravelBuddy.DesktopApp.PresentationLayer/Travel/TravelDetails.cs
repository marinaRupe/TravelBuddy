using System;
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
using TravelBuddy.DesktopApp.ViewModels;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class TravelDetails : Form, ITravelDetailsView
    {
        private readonly ITravelController _travelController;
        private readonly TravelViewModel _travelModel;
        public TravelDetails(ITravelController travelController, TravelViewModel travelModel)
        {
            _travelController = travelController;
            _travelModel = travelModel;

            InitializeComponent();
        }

        private void UpdateDetails()
        {
            nameOutput.Text = _travelModel.Name;
            descriptionOutput.Text = _travelModel.Description;

            dateStartPicker.Value = _travelModel.DateStart;
            dateStartPicker.Enabled = false;

            dateEndPicker.Value = _travelModel.DateStart;
            dateEndPicker.Enabled = false;

            budgetOutput.Text = $"{_travelModel.Budget.Value} {_travelModel.Budget.Currency.Shortcut}";
        }

        public void ShowModaless()
        {
            UpdateDetails();

            Show();
        }

        private void travelItemListBtn_Click(object sender, EventArgs e)
        {
            _travelController.OpenTravelItemListWindow(_travelModel.Id);
        }

        private void preliminaryActivityListBtn_Click(object sender, EventArgs e)
        {
            _travelController.OpenPreliminaryListWindow(_travelModel.Id);
        }

        private void CostListBtn_Click(object sender, EventArgs e)
        {
            _travelController.OpenCostListWindow(_travelModel.Id);
        }

        private void ActivityListBtn_Click(object sender, EventArgs e)
        {
            _travelController.OpenTravelActivityListWindow(_travelModel.Id);
        }
    }
}
