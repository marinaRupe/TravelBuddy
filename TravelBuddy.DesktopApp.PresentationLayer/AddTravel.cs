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
        private readonly IList<Currency> _currencyList;
        public AddTravel(ITravelController travelController, IList<Currency> currencyList)
        {
            _travelController = travelController;
            _currencyList = currencyList;

            InitializeComponent();
        }

        private void addTravelBtn_Click(object sender, EventArgs e)
        {
            Hide();

            var travel = new AddTravelViewModel
            {
                Name = travelNameInput.Text,
                Description = descriptionInput.Text,
                DateStart = dateStartPicker.Value,
                DateEnd = dateEndPicker.Value,
                Budget = new MoneyValue
                {
                    Value = (double)budgetInput.Value,
                    Currency = currencyListBox.SelectedItem as Currency
                }
            };

            _travelController.AddTravel(travel);
        }

        public void UpdateCurrencyList()
        {
            budgetInput.Maximum = decimal.MaxValue;
            currencyListBox.DataSource = _currencyList;
            currencyListBox.ValueMember = "Shortcut";
        }

        public void ShowModaless()
        {
            UpdateCurrencyList();

            Show();
        }
    }
}
