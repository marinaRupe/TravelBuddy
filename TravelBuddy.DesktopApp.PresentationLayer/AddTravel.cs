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
    public partial class AddTravel : Form, IAddTravelView
    {
        private readonly ITravelController _travelController;
        public AddTravel(ITravelController travelController)
        {
            _travelController = travelController;

            InitializeComponent();
        }

        private void addTravelBtn_Click(object sender, EventArgs e)
        {
            var travel = new AddTravelViewModel
            {
                Name = travelNameInput.Text,
                Description = descriptionInput.Text,
                DateStart = dateStartPicker.Value,
                DateEnd = dateEndPicker.Value,
                Budget = null
                /*
                Budget = new MoneyValue
                {
                    Value = 500,
                    Currency = new Currency()
                }
                */
            };

            _travelController.AddTravel(travel);
        }

        public void ShowModaless()
        {
            Show();
        }
    }
}
