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
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class TravelItemList : Form, ITravelItemListView
    {
        private readonly ITravelController _travelController;
        private readonly IList<TravelItem> _travelItemList;
        public TravelItemList(ITravelController travelController, IList<TravelItem> travelItemList)
        {
            _travelController = travelController;
            _travelItemList = travelItemList;

            InitializeComponent();
        }

        private void UpdateList()
        {
            listBox.DataSource = _travelItemList;
            listBox.ValueMember = "Name";
        }

        public void ShowModaless()
        {
            UpdateList();

            Show();
        }
    }
}
