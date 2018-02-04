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

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class Register : Form, IRegisterView
    {
        private readonly IMainController _controller;
        public Register(IMainController mainController)
        {
            _controller = mainController;

            InitializeComponent();
        }

        public void ShowModaless()
        {
            Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var username = usernameInput.Text;
            var email = emailInput.Text;
            var password = passwordInput.Text;

            _controller.Register(username, email, password);

            Hide();
        }
    }
}
