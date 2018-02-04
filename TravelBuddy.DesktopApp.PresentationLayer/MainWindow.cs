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
using TravelBuddy.DesktopApp.Controllers;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class MainWindow : Form, IMainView
    {
        private readonly IMainController _controller;
        private readonly WindowFormsFactory _formsFactory = new WindowFormsFactory();

        public MainWindow(IMainController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        public void ShowModaless()
        {
            Show();
        }

        private void travelListButton_Click(object sender, EventArgs e)
        {

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _controller.Logout();

            Hide();
        }
    }
}
