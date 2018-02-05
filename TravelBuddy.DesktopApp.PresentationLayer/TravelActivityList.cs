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
    public partial class TravelActivityList : Form, ITravelActivityListView
    {
        private readonly ITravelController _travelController;
        private readonly IList<TravelActivity> _travelActivityList;
        public TravelActivityList(ITravelController travelController, IList<TravelActivity> travelActivityList)
        {
            _travelController = travelController;
            _travelActivityList = travelActivityList;

            InitializeComponent();
        }

        private void UpdateList()
        {
        }

        public void ShowModaless()
        {
            UpdateList();

            Show();
        }
    }
}
