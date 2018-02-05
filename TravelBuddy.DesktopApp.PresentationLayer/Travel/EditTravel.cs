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
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class EditTravel : Form, IEditTravelView
    {
        private readonly ITravelController _travelController;
        private readonly EditTravelViewModel _travelModel;
        private readonly IList<Currency> _currencyList;
        public EditTravel(ITravelController travelController, EditTravelViewModel model, IList<Currency> currencyList)
        {
            _travelController = travelController;
            _travelModel = model;
            _currencyList = currencyList;

            InitializeComponent();
        }

        private void InitializeInputs()
        {
            travelNameInput.Text = _travelModel.Name;
            descriptionInput.Text = _travelModel.Description;
            dateStartPicker.Value = _travelModel.DateStart;
            dateEndPicker.Value = _travelModel.DateEnd;

            budgetInput.Maximum = decimal.MaxValue;
            budgetInput.Value = (decimal)_travelModel.Budget.Value;

            currencyListBox.DataSource = _currencyList;
            currencyListBox.ValueMember = "Shortcut";
            currencyListBox.SelectedItem = _travelModel.Budget.Currency;
        }

        public void ShowModaless()
        {
            InitializeInputs();

            Show();
        }

        private void saveTravelBtn_Click(object sender, EventArgs e)
        {
            Hide();

            var travelModel = new EditTravelViewModel
            {
                Id = _travelModel.Id,
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

            _travelController.SaveEditedTravel(travelModel);
        }
    }
}
