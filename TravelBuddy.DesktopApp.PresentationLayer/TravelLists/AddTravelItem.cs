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

namespace TravelBuddy.DesktopApp.PresentationLayer.TravelLists
{
    public partial class AddTravelItem : Form, IAddTravelItemView
    {
        private readonly ITravelController _travelController;
        private readonly Guid _travelId;
        public AddTravelItem(ITravelController travelController, Guid travelId)
        {
            _travelController = travelController;
            _travelId = travelId;

            InitializeComponent();
        }

        public void ShowModaless()
        {
            Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Hide();

            var travelItemModel = new AddTravelItemViewModel
            {
                Name = nameInput.Text,
                Description = descriptionInput.Text,
                IsTaken = isTakenInput.Checked
            };

            _travelController.AddTravelItem(travelItemModel, _travelId);
        }
    }
}
