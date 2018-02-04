using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.DesktopApp.Controllers;

namespace TravelBuddy.DesktopApp.PresentationLayer
{
    public partial class MainWindow : Form
    {
        private readonly MainFormController _controller;
        private readonly WindowFormsFactory _formsFactory = new WindowFormsFactory();

        public MainWindow(MainFormController controller)
        {
            _controller = controller;
            InitializeComponent();
        }


    }
}
