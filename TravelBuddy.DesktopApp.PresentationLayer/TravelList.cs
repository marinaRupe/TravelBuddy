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
using TravelBuddy.DesktopApp.ViewModels;
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class TravelList : Form, ITravelListView
    {
        private readonly ITravelController _travelController;
        private readonly IList<Travel> _travels;
        public TravelList(ITravelController travelController, IList<Travel> travels)
        {
            _travelController = travelController;
            _travels = travels;
            InitializeComponent();
        }

        private void UpdateList()
        {
            travelListBox.DataSource = _travels;
            travelListBox.DisplayMember = "Name";
        }

        public void ShowModaless()
        {
            UpdateList();

            Show();
        }

        private void addTravelBtn_Click(object sender, EventArgs e)
        {
            _travelController.OpenAddTravelWindow();
        }

        void travelListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = travelListBox.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches) return;

            var travel = (Travel)travelListBox.Items[index];

            var travelModel = new EditTravelViewModel
            {
                Id = travel.Id,
                Name = travel.Name,
                Description = travel.Description,
                DateStart = travel.DateStart,
                DateEnd = travel.DateEnd,
                Budget = travel.Budget
            };

            _travelController.EditTravel(travelModel);
        }
    }
}
