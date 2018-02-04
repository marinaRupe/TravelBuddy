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
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class Login : Form, ILoginView
    {
        private readonly IMainController _controller;
        public Login(IMainController mainController)
        {
            _controller = mainController;

            InitializeComponent();
        }

        public void ShowModaless()
        {
            Show();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            Hide();

            _controller.ShowRegisterWindow();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var username = usernameInput.Text;
            var password = passwordInput.Text;

            Hide();

            _controller.Login(username, password);
        }
    }
}
